namespace ContaCorrentePOO
{
    internal class ContaCorrente
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
                        AtualizarRegistroMovimentacoes(conta, $"Operação: Saque | Valor: R$ {valor.ToString("F")} " +
                            $"| Saldo: {conta.saldo.ToString("F2")} | Data: {DateTime.Now}");
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
                    AtualizarRegistroMovimentacoes(conta, $"Operação: Depósito | Valor: R$ {valor.ToString("F")} " +
                        $"| Saldo: {conta.saldo.ToString("F2")} | Data: {DateTime.Now}");
                    mensagemRetorno = $"\nDepósito no valor de R$ {valor.ToString("F2")} realizado com sucesso! Pressione ENTER para continuar...";
                    IncrementarQtdMovimentacoes(conta);
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
                                AtualizarRegistroMovimentacoes(contaOrigem, $"Operação: Transferência enviada | Valor: R$ {valor.ToString("F")} " +
                                    $"| Saldo: {contaOrigem.saldo.ToString("F2")} | Data: {DateTime.Now}");
                                AtualizarRegistroMovimentacoes(contaDestino, $"Operação: Transferência recebida | Valor: R$ {valor.ToString("F")} " +
                                    $"| Saldo: {contaDestino.saldo.ToString("F2")} | Data: {DateTime.Now}");
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

        public void AtualizarRegistroMovimentacoes(ContaCorrente conta, string registro)
        {
            conta.registroMovimentacoes[conta.qtdMovimentacoes] = registro;
        }

        public void IncrementarQtdMovimentacoes(ContaCorrente conta)
        {
            conta.qtdMovimentacoes++;
        }
    }
}
