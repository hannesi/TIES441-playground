using Tietoverkko;
using OperatingSystem = Tietoverkko.OperatingSystem;

var acme = new Acme();
var bonc = new Bonc();
var fedora = new OperatingSystem("Fedora", acme);
fedora.ReceiveDataFromNetwork();
fedora.SetNetworkModule(bonc);
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

    internal class Acme : INetworkModule
    {
        private bool _connectionStatus = false;

        public void Connect()
        {
            _connectionStatus = true;
        }

        public void Disconnect()
        {
            _connectionStatus = false;
        }

        public void SendData(string data)
        {
            if (_connectionStatus)
            {
                Console.WriteLine("Sending data through Acme");
            }
            else
            {
                Console.WriteLine("Acme is not connected to a network.");
            }
        }

        public string ReceiveData()
        {
            return _connectionStatus ? "Data from Acme" : "";
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
    }
}
