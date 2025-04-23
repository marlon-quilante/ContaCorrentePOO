namespace ContaCorrentePOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ContaCorrente conta1 = new ContaCorrente();
                ContaCorrente conta2 = new ContaCorrente();
                ApresentarCabecalhoInicial();
                ApresentarMenuOpcoes();
                int opcaoEscolhida = OpcaoDoMenu();
                
                switch (opcaoEscolhida)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            }
        }
        static void LimparTela()
        {
            Console.Clear();
        }

        static void ApresentarCabecalhoInicial()
        {
            LimparTela();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Controle de Conta Corrente");
            Console.WriteLine("--------------------------");
        }

        static void ApresentarMenuOpcoes()
        {
            Console.WriteLine("Escolha uma opção...");

            Console.WriteLine("1- Criar uma conta corrente");
            Console.WriteLine("2- Saque");
            Console.WriteLine("3- Depósito");
            Console.WriteLine("4- Consulta de saldo");
            Console.WriteLine("5- Emissão de extrato");
            Console.WriteLine("6- Transferência entre contas");
        }

        static int OpcaoDoMenu()
        {
            return Console.ReadLine();
        }
    }
}
