using System;
using System.Drawing;
using System.Collections.Generic;

namespace Spacesim
{
	public class SpaceObject
	{
		public String name;
		public double orbitalRadius;
		public double orbitalDuration;
		protected double objectRadius;
		protected double rotationalPeriod;
		protected String objectcolor;
		public double xpos;
		public double ypos;
		public String origin;
		public SpaceObject(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, String objectcolor, double xpos, double ypos, String origin)
		{
			this.name = name;
			this.orbitalRadius = orbitalRadius;
			this.orbitalDuration = orbitalDuration;
			this.objectRadius = objectRadius;
			this.rotationalPeriod = rotationalPeriod;
			this.objectcolor = objectcolor;
			this.xpos = xpos;
			this.ypos = ypos;
			this.origin = origin;
		}

		public virtual void Draw()
		{
			Console.WriteLine("");
			Console.WriteLine(name);
			Console.WriteLine("Orbital Radius(km): \t \t" + orbitalRadius);
			Console.WriteLine("Orbital Duration(days): \t" + orbitalDuration);
			Console.WriteLine("Object Diameter(km): \t \t" + objectRadius);
			Console.WriteLine("Rotational Period(days): \t" + rotationalPeriod);
			Console.WriteLine("Color: \t \t \t \t" + objectcolor);
			Console.Write("X Pos: " + xpos);
			Console.Write(" Y Pos: " + ypos);
			Console.WriteLine("\n");
		}
		public virtual void calcPos(int tid) {
			xpos = 0;
			ypos = 0;
		}

	}

	public class Star : SpaceObject
	{
		public Star(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, String objectcolor, double xpos, double ypos, String origin) : base(name, orbitalRadius, orbitalDuration, objectRadius, rotationalPeriod, objectcolor, xpos, ypos, origin) { }
		public override void Draw()
		{
			Console.Write("Star: ");
			base.Draw();
		}
	}
	public class Planet : SpaceObject
	{
		public Planet(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, String objectcolor, double xpos, double ypos, String origin) : base(name, orbitalRadius, orbitalDuration, objectRadius, rotationalPeriod, objectcolor, xpos, ypos, origin) { }
		public override void Draw()
		{
			Console.Write("Planet: ");
			base.Draw();
		}
		public override void calcPos(int time)
		{
			double orbitSpeed = ((2 * orbitalRadius * Math.PI) / (orbitalDuration));
			double angle = (orbitSpeed / orbitalRadius) * time;

			xpos = Math.Round(Math.Cos(angle) * orbitalRadius);
			ypos = Math.Round(Math.Sin(angle) * orbitalRadius);
		}

	}

	public class Satellite : Planet
	{
		Planet planet { get; set; }
		
		public Satellite(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, String objectcolor, double xpos, double ypos, String origin, Planet planet) : base(name, orbitalRadius, orbitalDuration, objectRadius, rotationalPeriod, objectcolor, xpos, ypos, origin) 
		{
			this.planet = planet;
		}

		public override void Draw()
		{
			Console.Write("Moon  : ");
			base.Draw();
		}
		public override void calcPos(int time)
		{
			double orbitSpeed = ((2 * orbitalRadius * Math.PI) / (orbitalDuration));
			double angle = (orbitSpeed / orbitalRadius) * time;

			xpos = planet.xpos + Math.Round(Math.Cos(angle) * orbitalRadius);
			ypos = planet.ypos + Math.Round(Math.Sin(angle) * orbitalRadius);
		}

	}
	public class Comet : SpaceObject
	{
		public Comet(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, String objectcolor, double xpos, double ypos, String origin) : base(name, orbitalRadius, orbitalDuration, objectRadius, rotationalPeriod, objectcolor, xpos, ypos, origin) { }
		public override void Draw()
		{
			Console.Write("Comet: ");
			base.Draw();
		}
	}
	public class Asteroid : SpaceObject
	{
		public Asteroid(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, String objectcolor, double xpos, double ypos, String origin) : base(name, orbitalRadius, orbitalDuration, objectRadius, rotationalPeriod, objectcolor, xpos, ypos, origin) { }
		public override void Draw()
		{
			Console.Write("Asteroid: ");
			base.Draw();
		}
	}
	public class AsteroidBelt : Asteroid
	{
		public AsteroidBelt(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, String objectcolor, double xpos, double ypos, String origin) : base(name, orbitalRadius, orbitalDuration, objectRadius, rotationalPeriod, objectcolor, xpos, ypos, origin) { }
		public override void Draw()
		{
			Console.Write("Asteroid Belt: ");
			base.Draw();
		}
	}

	public class Dwarf : Planet
	{
		public Dwarf(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, String objectcolor, double xpos, double ypos, String origin) : base(name, orbitalRadius, orbitalDuration, objectRadius, rotationalPeriod, objectcolor, xpos, ypos, origin) { }
		public override void Draw()
		{
			Console.Write("Dwarf Planet: ");
			base.Draw();
		}
	}


}