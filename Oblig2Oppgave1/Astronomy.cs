using System;
using System.IO;
using System.Collections.Generic;
using SpaceSim;
using System.Drawing;

class Astronomy
{
	public static void Main()
	{
		List<SpaceObject> solarSystem = new List<SpaceObject>
		{
			new Star("Sun",0,0,4370005.6,0,"Red", 0,0, ""),
			new Planet("Mercury", 57909227, 87.97, 4879,58.65, "Orange",57909227,0,"Sun"),
			new Planet("Venus", 108200000,224.65,12104,116.18,"Brown", 108200000,0,"Sun"),
			new Planet("Terra", 149500000, 365,12742,1,"Blue", 149500000, 0,"Sun"),
			new Satellite("The Moon",384400,27.32, 3474, 27.322, "Pink", 384400,0,"Terra", new Planet("Terra", 149500000, 365,12742,1,"Blue", 149500000, 0,"Sun")),
			new Comet("Hyakutake", 254316380190,69.69, 1337, 420, "Yellow", 254316380190,0,"Sun"),
			new Asteroid("Haumea",3245,  5435, 5234, 34234, "Green", 3245,0,"Sun"),
			new AsteroidBelt("Kuiper Belt",343557, 4343, 4343, 3434234, "Purple", 343557,0,"Sun"),
			new Dwarf("Pluto", 5900000000,90520,2376.6,6387,"White",5900000000,0,"Sun"),
			new Dwarf("Eris", 5669759299,203670,1163,1.08,"Gray", 5669759299,0,"Sun")
		};

		foreach (SpaceObject obj in solarSystem)
		{
			obj.Draw();
		}

		Console.WriteLine("");
		Console.WriteLine("Planet Name: ");
		bool planeteksisterer = false;
		string planetName = Console.ReadLine();
		int tid =0;
		foreach (SpaceObject obj in solarSystem)
		{
			if (planetName.ToUpper() == obj.name.ToUpper())
			{
				bool notanumber = true;
				while (notanumber) {
					Console.WriteLine("Tid (i dager): ");
					if (int.TryParse(Console.ReadLine(), out tid))
					{
						notanumber = false;
					}
					else {
						Console.WriteLine("Feil input, prøv igjen: ");
					}
				}
				
				obj.calcPos(tid);
				obj.Draw();
				planeteksisterer = true;
				foreach (SpaceObject child in solarSystem)
				{
					if (child.origin == obj.name)
					{
						child.calcPos(tid);
						child.Draw();
					}
				}
				
			}
		}
		if (!planeteksisterer) {
			solarSystem[0].Draw();
			foreach (SpaceObject obj2 in solarSystem) {
				if (solarSystem[0].name == obj2.origin) {
					obj2.Draw();
				}
			
			}
		}
		Console.ReadLine();
		
		



	}

}

