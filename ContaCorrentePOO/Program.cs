using System.Drawing;

namespace ContaCorrentePOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ContaCorrente> listaContas = new List<ContaCorrente>();
            bool acessoEmAndamento = true;

            while (acessoEmAndamento)
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
                        RealizarSaque(listaContas, valor);
                        break;
                    case 3:
                        RealizarDeposito(listaContas, valor);
                        break;
                    case 4:
                        ConsultarSaldo(listaContas);
                        break;
                    case 5:
                        EmitirExtrato(listaContas);
                        break;
                    case 6:
                        RealizarTransferencia(listaContas, valor);
                        break;
                    case 7:
                        acessoEmAndamento = false;
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
            Console.WriteLine("6- Transferência entre contas");
            Console.WriteLine("7- Sair\n");
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

        static int EscolherNumeroContaDestino()
        {
            Console.Write("\nInsira o número da conta de destino: ");
            return int.Parse(Console.ReadLine());
        }

        static void RealizarSaque(List<ContaCorrente> listaContas, double valor)
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
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\nValor do saque não é permitido! Pressione ENTER para continuar...");
                        Console.ReadLine();
                        return;
                    }
                }
            }
            Console.WriteLine("\nNúmero da conta não existe! Pressione ENTER para continuar...");
            Console.ReadLine();
        }

        static void RealizarDeposito(List<ContaCorrente> listaContas, double valor)
        {
            int numeroConta = EscolherNumeroConta();
            foreach (ContaCorrente conta in listaContas)
            {
                if (numeroConta == conta.numero)
                {
                    valor = DefinirValor();
                    conta.Depositar(valor, conta);
                    Console.WriteLine($"\nDepósito no valor de R$ {valor.ToString("F2")} realizado com sucesso! Pressione ENTER para continuar...");
                    Console.ReadLine();
                    return;
                }
            }
            Console.WriteLine("\nNúmero da conta não existe! Pressione ENTER para continuar...");
            Console.ReadLine();
        }

        static void ConsultarSaldo(List<ContaCorrente> listaContas)
        {
            int numeroConta = EscolherNumeroConta();
            foreach (ContaCorrente conta in listaContas)
            {
                if (numeroConta == conta.numero)
                {
                    Console.WriteLine($"\nSaldo da conta: R$ {conta.saldo.ToString("F2")}");
                    Console.WriteLine("\nPressione ENTER para continuar...");
                    Console.ReadLine();
                    return;
                }
            }
            Console.WriteLine("\nNúmero da conta não existe! Pressione ENTER para continuar...");
            Console.ReadLine();
        }

        static void EmitirExtrato(List<ContaCorrente> listaContas)
        {
            int numeroConta = EscolherNumeroConta();
            Console.WriteLine();

            foreach (ContaCorrente conta in listaContas)
            {
                if (numeroConta == conta.numero)
                {
                    for (int i = 0; i < conta.registroMovimentacoes.Length; i++)
                    {
                        if (conta.registroMovimentacoes[i] != null)
                        {
                            Console.WriteLine(conta.registroMovimentacoes[i]);
                        }
                    }
                    Console.WriteLine("\nPressione ENTER para continuar...");
                    Console.ReadLine();
                    return;
                }
            }
            Console.WriteLine("\nNúmero da conta não existe! Pressione ENTER para continuar...");
            Console.ReadLine();
        }

        static void RealizarTransferencia(List<ContaCorrente> listaContas, double valor)
        {
            int numeroContaOrigem = EscolherNumeroConta();

            foreach (ContaCorrente contaOrigem in listaContas)
            {
                if (numeroContaOrigem == contaOrigem.numero)
                {
                    int numeroContaDestino = EscolherNumeroContaDestino();

                    foreach (ContaCorrente contaDestino in listaContas)
                    {
                        if (numeroContaDestino == contaDestino.numero && numeroContaDestino != numeroContaOrigem)
                        {
                            valor = DefinirValor();

                            if (contaOrigem.TransferenciaPermitida(valor))
                            {
                                contaOrigem.Transferir(contaOrigem, contaDestino, valor);
                                Console.WriteLine($"\nTransferência no valor de R$ {valor.ToString("F2")} realizada com sucesso! Pressione ENTER para continuar...");
                                Console.ReadLine();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("\nValor da transferência não é permitida! Pressione ENTER para continuar...");
                                Console.ReadLine();
                                return;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("\nNúmero da conta não existe! Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
