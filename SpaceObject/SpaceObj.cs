using System;
using System.Drawing;
using System.Collections.Generic;
using Color = System.Windows.Media.Brush;

namespace SpaceSim
{
	public class SpaceObject
	{
		public String name;
		public double orbitalRadius;
		public double orbitalDuration;
		public double objectRadius;
		protected double rotationalPeriod;
		public Color objectcolor;
		public double xpos;
		public double ypos;
		public String origin;
		public SpaceObject(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, Color objectcolor, double xpos, double ypos, String origin)
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
		public virtual void calcPos(double tid)
		{
			xpos = 0;
			ypos = 0;
		}

	}

	public class Star : SpaceObject
	{
		public Star(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, Color objectcolor, double xpos, double ypos, String origin) : base(name, orbitalRadius, orbitalDuration, objectRadius, rotationalPeriod, objectcolor, xpos, ypos, origin) { }
		public override void Draw()
		{
			Console.Write("Star: ");
			base.Draw();
		}
	}
	public class Planet : SpaceObject
	{
		public Planet(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, Color objectcolor, double xpos, double ypos, String origin) : base(name, orbitalRadius, orbitalDuration, objectRadius, rotationalPeriod, objectcolor, xpos, ypos, origin) { }
		public override void Draw()
		{
			Console.Write("Planet: ");
			base.Draw();
		}
		public override void calcPos(double time)
		{
			double angularVelocoty = ((2 * Math.PI) / orbitalDuration);

			xpos = Math.Round(Math.Cos(angularVelocoty*time)*20* Math.Cbrt(orbitalRadius));
			ypos = Math.Round(Math.Sin(angularVelocoty*time)*20 * Math.Cbrt(orbitalRadius));
		}

	}

	public class Satellite : Planet
	{

		public Satellite(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, Color objectcolor, double xpos, double ypos, String origin) : base(name, orbitalRadius, orbitalDuration, objectRadius, rotationalPeriod, objectcolor, xpos, ypos, origin)
		{
		}

		public override void Draw()
		{
			Console.Write("Moon  : ");
			base.Draw();
		}
		public override void calcPos(double time)
		{
			double angularVelocoty = ((2 * Math.PI) / orbitalDuration);

			xpos = Math.Round(Math.Cos(angularVelocoty * time) * 20 * Math.Cbrt(orbitalRadius));
			ypos = Math.Round(Math.Sin(angularVelocoty * time) * 20 * Math.Cbrt(orbitalRadius));
		}

	}
	public class Comet : SpaceObject
	{
		public Comet(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, Color objectcolor, double xpos, double ypos, String origin) : base(name, orbitalRadius, orbitalDuration, objectRadius, rotationalPeriod, objectcolor, xpos, ypos, origin) { }
		public override void Draw()
		{
			Console.Write("Comet: ");
			base.Draw();
		}
		public override void calcPos(double time)
		{
			double angularVelocoty = ((2 * Math.PI) / orbitalDuration);

			xpos = Math.Round(Math.Cos(angularVelocoty * time) * 20 * Math.Cbrt(orbitalRadius));
			ypos = Math.Round(Math.Sin(angularVelocoty * time) * 20 * Math.Cbrt(orbitalRadius));
		}
	}
	public class Asteroid : SpaceObject
	{
		public Asteroid(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, Color objectcolor, double xpos, double ypos, String origin) : base(name, orbitalRadius, orbitalDuration, objectRadius, rotationalPeriod, objectcolor, xpos, ypos, origin) { }
		public override void Draw()
		{
			Console.Write("Asteroid: ");
			base.Draw();
		}
		public override void calcPos(double time)
		{
			double angularVelocoty = ((2 * Math.PI) / orbitalDuration);

			xpos = Math.Round(Math.Cos(angularVelocoty * time) * 20 * Math.Cbrt(orbitalRadius));
			ypos = Math.Round(Math.Sin(angularVelocoty * time) * 20 * Math.Cbrt(orbitalRadius));
		}
	}
	public class AsteroidBelt : Asteroid
	{
		public AsteroidBelt(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, Color objectcolor, double xpos, double ypos, String origin) : base(name, orbitalRadius, orbitalDuration, objectRadius, rotationalPeriod, objectcolor, xpos, ypos, origin) { }
		public override void Draw()
		{
			Console.Write("Asteroid Belt: ");
			base.Draw();
		}
		public override void calcPos(double time)
		{
			double angularVelocoty = ((2 * Math.PI) / orbitalDuration);

			xpos = Math.Round(Math.Cos(angularVelocoty * time) * 20 * Math.Cbrt(orbitalRadius));
			ypos = Math.Round(Math.Sin(angularVelocoty * time) * 20 * Math.Cbrt(orbitalRadius));
		}
	}

	public class Dwarf : Planet
	{
		public Dwarf(String name, double orbitalRadius, double orbitalDuration, double objectRadius, double rotationalPeriod, Color objectcolor, double xpos, double ypos, String origin) : base(name, orbitalRadius, orbitalDuration, objectRadius, rotationalPeriod, objectcolor, xpos, ypos, origin) { }
		public override void Draw()
		{
			Console.Write("Dwarf Planet: ");
			base.Draw();
		}
	}


}