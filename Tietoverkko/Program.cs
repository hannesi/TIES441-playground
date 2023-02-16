using System.Text;
using Tietoverkko;
using OperatingSystem = Tietoverkko.OperatingSystem;

var acme = new Acme();
var bonc = new Bonc();
var fedora = new OperatingSystem("Fedora", acme);
fedora.ReceiveDataFromNetwork();
fedora.ConnectNetwork();
fedora.ReceiveDataFromNetwork();
fedora.SendDataToNetwork();
fedora.DisconnectNetwork();
fedora.ReceiveDataFromNetwork();

Console.WriteLine("====SWAP TO BONC====");
fedora.SetNetworkModule(bonc);
fedora.ReceiveDataFromNetwork();
fedora.ConnectNetwork();
fedora.ReceiveDataFromNetwork();
fedora.SendDataToNetwork();
fedora.DisconnectNetwork();
fedora.ReceiveDataFromNetwork();

namespace Tietoverkko
{
    internal interface INetworkModule
    {
        void Connect();
        void Disconnect();
        void SendData(string data);
        string ReceiveData();
    }

    internal interface IPekanIhanItseKeksimaOmaTietoverkkoModuuliStandardi
    {
        void SetConnectionOpen(bool state);
        void Communicate(byte[] data, bool readFlag);
    }

    internal class PekanModuuli : IPekanIhanItseKeksimaOmaTietoverkkoModuuliStandardi
    {
        private bool _connectionState = false;
        public void SetConnectionOpen(bool state)
        {
            _connectionState = state;
        }

        public void Communicate(byte[] data, bool readFlag)
        {
            if (!_connectionState)
            {
                Console.WriteLine("Yhteys muodostamati. T. Pekka");
                return;
            }
            
            if (readFlag)
            {
                var message = Encoding.UTF8.GetBytes("Pekalta terveisiä");
                var dataCap = Math.Min(data.Length, message.Length);
                for (var i = 0; i < dataCap; i++)
                {
                    data[i] = message[i];
                }
            }
            else
            {
                    Console.WriteLine(
                        $"Pekan moduuli lähetteleepi dataa tietoverkkoon: {Encoding.UTF8.GetString(data)}");
            }
        }
    }

    internal class Acme : INetworkModule
    {
        private IPekanIhanItseKeksimaOmaTietoverkkoModuuliStandardi _actualNetworkModule = new PekanModuuli();

        public void Connect()
        {
            _actualNetworkModule.SetConnectionOpen(true);
        }

        public void Disconnect()
        {
            _actualNetworkModule.SetConnectionOpen(false);
        }

        public void SendData(string data)
        {
            Console.WriteLine("Sending data through Acme");
            var byteData = Encoding.UTF8.GetBytes(data);
            _actualNetworkModule.Communicate(byteData, false);
        }

        public string ReceiveData()
        {
            Console.WriteLine("Receiving data from Acme");
            var byteData = new byte[1024];
            _actualNetworkModule.Communicate(byteData, true);
            return Encoding.UTF8.GetString(byteData);
        }
    }

    internal class Bonc : INetworkModule
    {
        private bool _konnekshunShtaytus = false;

        public void Connect()
        {
            _konnekshunShtaytus = true;
        }

        public void Disconnect()
        {
            _konnekshunShtaytus = false;
        }

        public void SendData(string data)
        {
            if (_konnekshunShtaytus)
            {
                Console.WriteLine("Sending data through Bonc");
            }
            else
            {
                Console.WriteLine("Bonc is not connected");
            }
        }

        public string ReceiveData()
        {
            return _konnekshunShtaytus ? "Data from Bonc" : "";
        }
    }

    internal class OperatingSystem
    {
        private readonly string _name;
        private INetworkModule? _networkModule;

        public OperatingSystem(string name, INetworkModule? networkModule = null)
        {
            _name = name;
            if (networkModule != null) SetNetworkModule(networkModule);
        }

        public void SetNetworkModule(INetworkModule networkModule)
        {
            _networkModule = networkModule;
        }

        public void ReceiveDataFromNetwork()
        {
            Console.WriteLine($"{_name} received data from network: {_networkModule?.ReceiveData()}");
        }

        public void SendDataToNetwork()
        {
            _networkModule?.SendData($"This data was sent from a {_name} operating system");
        }

        public void ConnectNetwork() => _networkModule?.Connect();

        public void DisconnectNetwork() => _networkModule?.Disconnect();
    }
}
