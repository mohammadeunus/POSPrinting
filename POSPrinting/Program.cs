using System;
using System.IO.Ports;
using System.Text;

using POSPrinting;

// Get input data from the user
string foodName = "HamburgerSandwich";
string columnsBody = "This hamburger sandwich was delicious! Perfectly cooked patty, fresh toppings, and a soft bun made for a great balance of flavors and textures.";
string dateTime = DateTime.Now.ToString("hh:mm:ss tt");
byte CharInEachLine = 42;
byte spaceCountBetweenColumn = 1;


// Create a new instance of the ReceiptPrinter class and ...
MakeALine ORestaurant = new MakeALine(foodName, columnsBody, dateTime);
ORestaurant.Modify(CharInEachLine, spaceCountBetweenColumn);
ORestaurant.PrintLines();
