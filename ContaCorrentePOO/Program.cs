using System.Drawing;

namespace ContaCorrentePOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ContaCorrente> listaContas = new List<ContaCorrente>();

            while (true)
            {
                double valor = 0;

                ApresentarCabecalhoInicial();
                ApresentarMenuOpcoes();
                int opcaoEscolhida = OpcaoDoMenu();

                switch (opcaoEscolhida)
                {
                    case 1:
                        CriarConta(listaContas);
                        break;
                    case 2:
                        if (SaqueRealizado(listaContas, valor))
                            break;
                        break;
                    case 3:
                        if (DepositoRealizado(listaContas, valor))
                            break;
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

        static void ApresentarCabecalhoInicial()
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Controle de Conta Corrente");
            Console.WriteLine("--------------------------");
        }

        static void ApresentarMenuOpcoes()
        {
            Console.WriteLine("\nEscolha uma opção...\n");

            Console.WriteLine("1- Criar uma conta corrente");
            Console.WriteLine("2- Saque");
            Console.WriteLine("3- Depósito");
            Console.WriteLine("4- Consulta de saldo");
            Console.WriteLine("5- Emissão de extrato");
            Console.WriteLine("6- Transferência entre contas\n");
        }

        static int OpcaoDoMenu()
        {
            return int.Parse(Console.ReadLine());
        }

        static double DefinirValor()
        {
            Console.Write("\nInsira o valor da operação: ");
            return double.Parse(Console.ReadLine());
        }

        static void CriarConta(List<ContaCorrente> listaContas)
        {
            ContaCorrente conta = new ContaCorrente();

            Console.Write("\nInsira o número da conta: ");
            conta.numero = int.Parse(Console.ReadLine());
            Console.Write("Insira o saldo da conta: ");
            conta.saldo = double.Parse(Console.ReadLine());
            Console.Write("Insira o limite de débito da conta: ");
            conta.limiteDebito = double.Parse(Console.ReadLine());

            listaContas.Add(conta);
        }

        static int EscolherNumeroConta()
        {
            Console.Write("\nInsira o número da conta para a operação: ");
            return int.Parse(Console.ReadLine());
        }

        static bool SaqueRealizado(List<ContaCorrente> listaContas, double valor)
        {
            int numeroConta = EscolherNumeroConta();
            foreach (ContaCorrente conta in listaContas)
            {
                if (numeroConta == conta.numero)
                {
                    valor = DefinirValor();
                    if (conta.SaquePermitido(valor))
                    {
                        conta.Sacar(valor, conta);
                        Console.WriteLine($"\nSaque no valor de R$ {valor.ToString("F2")} realizado com sucesso! Pressione ENTER para continuar...");
                        Console.WriteLine($"Saldo atual: {conta.saldo.ToString("F2")}");
                        Console.ReadLine();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Valor do saque não é permitido! Pressione ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    }
                }
            }
            Console.WriteLine("\nNúmero da conta não existe! Pressione ENTER para continuar...");
            Console.ReadLine();
            return false;
        }

        static bool DepositoRealizado(List<ContaCorrente> listaContas, double valor)
        {
            int numeroConta = EscolherNumeroConta();
            foreach (ContaCorrente conta in listaContas)
            {
                if (numeroConta == conta.numero)
                {
                    valor = DefinirValor();
                    conta.Depositar(valor, conta);
                    Console.WriteLine($"\nDepósito no valor de R$ {valor.ToString("F2")} realizado com sucesso! Pressione ENTER para continuar...");
                    Console.WriteLine($"Saldo atual: {conta.saldo.ToString("F2")}");
                    Console.ReadLine();
                    return true;
                }
            }
            Console.WriteLine("\nNúmero da conta não existe! Pressione ENTER para continuar...");
            Console.ReadLine();
            return false;
        }
    }
}
