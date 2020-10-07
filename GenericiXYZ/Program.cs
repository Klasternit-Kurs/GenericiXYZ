using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericiXYZ
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> listaBrojeva;
			List<string> listaTxt;
			Osoba x = new Osoba { Ime = "Pera" };
			Osoba y = new Osoba { Ime = "Neko" };

			Zamenjivac<Osoba> z = new Zamenjivac<Osoba>();
			z.Zameni(x, y);

			Zamenjivac<int> z2 = new Zamenjivac<int>();
			z2.Zameni(2, 4);

			NekaMojaLista<string> nml = new NekaMojaLista<string>();
			nml.Dodaj("asd");
			nml.Dodaj("boo");
			nml.Dodaj("zxc");
			nml.Dodaj("23");

			while (nml.Velicina > 0)
				Console.WriteLine(nml.Izvuci());
			Console.ReadLine();

		}
	}

	class NekaMojaLista<T>
	{
		private T[] _stvari = new T[0];

		public int Velicina { get => _stvari.Length; }

		public void Dodaj(T nesto)
		{
			Array.Resize<T>(ref _stvari, _stvari.Length + 1);
			_stvari[_stvari.Length - 1] = nesto;
		}

		public T Izvuci()
		{
			if (_stvari.Any())
			{
				T temp = _stvari[0];
				T[] tempNiz = new T[_stvari.Length - 1];
				Array.Copy(_stvari, 1, tempNiz, 0, _stvari.Length - 1);
				_stvari = tempNiz;
				return temp;
			}
			return default(T);
		}
	}



	class Zamenjivac<T>
	{
		public void Zameni(T a, T b)
		{
			T temp = a;
			a = b;
			b = temp;
		}
	}

	class Osoba
	{
		public string Ime;
	}
}
