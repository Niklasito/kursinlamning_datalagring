using kursinlamning_datalagring.Services;

var mainMenu = new MenuService();

while (true)
{
    await mainMenu.StartMenuInterface();
}
