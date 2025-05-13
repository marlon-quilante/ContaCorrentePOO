namespace ContaCorrentePOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ContaCorrente> listaContas = new List<ContaCorrente>();
            ContaCorrente conta = new ContaCorrente();

            bool acessoEmAndamento = true;

            while (acessoEmAndamento)
            {
                double valor = 0;
                int numeroConta = 0;

                ApresentarCabecalhoInicial();
                ApresentarMenuOpcoes();
                int opcaoEscolhida = OpcaoDoMenu();

                switch (opcaoEscolhida)
                {
                    case 1:
                        CriarConta(listaContas);
                        break;
                    case 2:
                        numeroConta = EscolherNumeroConta();
                        valor = DefinirValor();
                        conta.RealizarSaque(listaContas, valor, numeroConta);
                        ApresentarMensagemRetorno(conta);
                        break;
                    case 3:
                        numeroConta = EscolherNumeroConta();
                        valor = DefinirValor();
                        conta.RealizarDeposito(listaContas, valor, numeroConta);
                        ApresentarMensagemRetorno(conta);
                        break;
                    case 4:
                        numeroConta = EscolherNumeroConta();
                        conta.ConsultarSaldo(listaContas, numeroConta);
                        ApresentarMensagemRetorno(conta);
                        break;
                    case 5:
                        numeroConta = EscolherNumeroConta();
                        EmitirExtrato(listaContas, numeroConta);
                        break;
                    case 6:
                        int numeroContaOrigem = EscolherNumeroConta();
                        int numeroContaDestino = EscolherNumeroContaDestino();
                        valor = DefinirValor();
                        conta.RealizarTransferencia(listaContas, valor, numeroContaOrigem, numeroContaDestino);
                        ApresentarMensagemRetorno(conta);
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

        static void EmitirExtrato(List<ContaCorrente> listaContas, int numeroConta)
        {
            Console.WriteLine();
            foreach (ContaCorrente conta in listaContas)
            {
                if (numeroConta == conta.numero)
                {
                    for (int i = 0; i < conta.registroMovimentacoes.Length; i++)
                    {
                        string movimentacaoAtual = conta.registroMovimentacoes[i];

                        if (conta.registroMovimentacoes[i] != null)
                        {
                            Console.WriteLine(movimentacaoAtual);
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

        static void ApresentarMensagemRetorno(ContaCorrente conta)
        {
            Console.WriteLine(conta.mensagemRetorno);
            Console.ReadLine();
        }
    }
}
