using System;

namespace series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            
            string OpcaoUsuario = ObterOpcao();

            while(OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
						ListarSeries();
						break;
					case "2":
				    	InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

                    default:
                    throw new ArgumentOutOfRangeException();
                   
                }

               OpcaoUsuario = ObterOpcao();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
            
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da serie ");

            ListarSeries();

            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar series");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie encontrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();

                Console.WriteLine("#ID {0}: = {1} {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");

            foreach (int i  in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genero :");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da serie :");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de incio da serie :");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();

            Series novaserie = new Series(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao           
            );

            repositorio.Insere(novaserie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da serie");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i  in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genero :");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da serie :");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de incio da serie :");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(
                                        id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao


            );

            repositorio.Atualiza(indiceSerie, atualizaSerie);
            
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Qual serie deseja excluir ");

            ListarSeries();
            

            int indiceserie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceserie);
        }
        private static string ObterOpcao()
        {
            Console.WriteLine();
			
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");

			Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}
