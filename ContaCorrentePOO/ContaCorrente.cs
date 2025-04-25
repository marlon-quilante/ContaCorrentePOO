namespace ContaCorrentePOO
{
    public class ContaCorrente
    {
        public int numero = 0;
        public double saldo = 0.0F;
        public double limiteDebito = 0.0F;
        public string[] registroMovimentacoes = new string[50];
        public int qtdMovimentacoes = 0;
        public string mensagemRetorno = "";

        public bool SaquePermitido(double valor)
        {
            if ((valor <= (saldo + limiteDebito)) && (valor >= 0))
                return true;
            else
                return false;
        }

        public bool TransferenciaPermitida(double valor)
        {
            if (valor <= saldo)
                return true;
            else
                return false;
        }

        public void RealizarSaque(List<ContaCorrente> listaContas, double valor, int numeroConta)
        {
            foreach (ContaCorrente conta in listaContas)
            {
                if (numeroConta == conta.numero)
                {
                    if (conta.SaquePermitido(valor))
                    {
                        conta.saldo -= valor;
                        AtualizarRegistroMovimentacoes(conta, valor, "Saque", DateTime.Now);
                        IncrementarQtdMovimentacoes(conta);
                        mensagemRetorno = $"\nSaque no valor de R$ {valor.ToString("F2")} realizado com sucesso! Pressione ENTER para continuar...";
                        return;
                    }
                    else
                    {
                        mensagemRetorno = "\nValor do saque não é permitido! Pressione ENTER para continuar...";
                        return;
                    }
                }
            }
            mensagemRetorno = "\nNúmero da conta não existe! Pressione ENTER para continuar...";
        }

        public void RealizarDeposito(List<ContaCorrente> listaContas, double valor, int numeroConta)
        {
            foreach (ContaCorrente conta in listaContas)
            {
                if (numeroConta == conta.numero)
                {
                    conta.saldo += valor;
                    AtualizarRegistroMovimentacoes(conta, valor, "Depósito", DateTime.Now);
                    IncrementarQtdMovimentacoes(conta);
                    mensagemRetorno = $"\nDepósito no valor de R$ {valor.ToString("F2")} realizado com sucesso! Pressione ENTER para continuar...";
                    return;
                }
            }
            mensagemRetorno = "\nNúmero da conta não existe! Pressione ENTER para continuar...";
        }

        public void ConsultarSaldo(List<ContaCorrente> listaContas, int numeroConta)
        {
            foreach (ContaCorrente conta in listaContas)
            {
                if (numeroConta == conta.numero)
                {
                    mensagemRetorno = $"\nSaldo da conta: R$ {conta.saldo.ToString("F2")}\n\nPressione ENTER para continuar...";
                    return;
                }
            }
            mensagemRetorno = "\nNúmero da conta não existe! Pressione ENTER para continuar...";
        }

        public void RealizarTransferencia(List<ContaCorrente> listaContas, double valor, int numeroContaOrigem, int numeroContaDestino)
        {
            foreach (ContaCorrente contaOrigem in listaContas)
            {
                if (numeroContaOrigem == contaOrigem.numero)
                {
                    foreach (ContaCorrente contaDestino in listaContas)
                    {
                        if (numeroContaDestino == contaDestino.numero && numeroContaDestino != numeroContaOrigem)
                        {
                            if (contaOrigem.TransferenciaPermitida(valor))
                            {
                                contaOrigem.saldo -= valor;
                                contaDestino.saldo += valor;
                                AtualizarRegistroMovimentacoes(contaOrigem, valor, "Transferência enviada", DateTime.Now);
                                AtualizarRegistroMovimentacoes(contaDestino, valor, "Transferência recebida", DateTime.Now);
                                IncrementarQtdMovimentacoes(contaOrigem);
                                IncrementarQtdMovimentacoes(contaDestino);
                                mensagemRetorno = $"\nTransferência no valor de R$ {valor.ToString("F2")} realizada com sucesso! Pressione ENTER para continuar...";
                                return;
                            }
                            else
                            {
                                mensagemRetorno = "\nValor da transferência não é permitido! Pressione ENTER para continuar...";
                                return;
                            }
                        }
                    }
                }
            }
            mensagemRetorno = "\nNúmero da conta não existe! Pressione ENTER para continuar...";
        }

        public void AtualizarRegistroMovimentacoes(ContaCorrente conta, double valor, string tipo, DateTime dataHora)
        {
            Movimentacao novaMovimentacao = new Movimentacao();
            novaMovimentacao.valor = valor;
            novaMovimentacao.tipo = tipo;
            novaMovimentacao.dataHora = dataHora;

            conta.registroMovimentacoes[conta.qtdMovimentacoes] = novaMovimentacao.RegistroMovimentacao(conta);
        }

        public void IncrementarQtdMovimentacoes(ContaCorrente conta)
        {
            conta.qtdMovimentacoes++;
        }
    }
}
