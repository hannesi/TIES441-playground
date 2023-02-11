using FunTimesItemCraftingNetwork;

var pipe = new Connector();
var miniatureCoffeeFarm = new ItemGenerator(Item.CoffeeBeans);
var coffeeBeanCrusher = new ItemCrafter(new[] { Item.CoffeeBeans }, Item.GroundCoffeeBeans);
var infiniteWaterSource = new ItemGenerator(Item.Water);
var coffeeMaker = new ItemCrafter(new []{Item.GroundCoffeeBeans, Item.Water}, Item.Coffee);
var milkableAnimal = new ItemGenerator(Item.Milk);
var milkPourerSpecializedInLatte = new ItemCrafter(new [] { Item.Coffee , Item.Milk}, Item.Latte);
var craftingTerminal = new CraftingTerminal();

// Single-pipe system
// craftingTerminal.Attach(pipe);
// miniatureCoffeeFarm.Attach(pipe);
// coffeeBeanCrusher.Attach(pipe);
// infiniteWaterSource.Attach(pipe);
// coffeeMaker.Attach(pipe);
// milkableAnimal.Attach(pipe);
// milkPourerSpecializedInLatte.Attach(pipe);
// craftingTerminal.CheckAvailability(Item.Latte);
// infiniteWaterSource.Detach(pipe);
// craftingTerminal.CheckAvailability(Item.Latte);


// dual-pipe system with coffee beans and ground coffee beans unreachable from the terminal
craftingTerminal.Attach(pipe);
infiniteWaterSource.Attach(pipe);
coffeeMaker.Attach(pipe);
milkableAnimal.Attach(pipe);
milkPourerSpecializedInLatte.Attach(pipe);

craftingTerminal.CheckAvailability(Item.Latte);

var unreachablePipe = new Connector();
miniatureCoffeeFarm.Attach(unreachablePipe);
coffeeBeanCrusher.Attach(unreachablePipe);

craftingTerminal.CheckAvailability(Item.Latte);

coffeeMaker.Attach(unreachablePipe);

craftingTerminal.CheckAvailability(Item.Latte);
craftingTerminal.CheckAvailability(Item.CoffeeBeans);
