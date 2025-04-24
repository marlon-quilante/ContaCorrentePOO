namespace ContaCorrentePOO
{
    internal class ContaCorrente
    {
        public int numero = 0;
        public double saldo = 0.0F;
        public double limiteDebito = 0.0F;
        public string[] registroMovimentacoes = new string[50];
        public int qtdMovimentacoes = 0;

        public void Sacar(double valor, ContaCorrente conta)
        {
            saldo -= valor;
            conta.registroMovimentacoes[qtdMovimentacoes] = $"Saque na conta de número {conta.numero}: R$ {valor.ToString("F")} | {DateTime.Now}";
            conta.qtdMovimentacoes++;
        }

        public bool SaquePermitido(double valor)
        {
            if ((valor <= (saldo + limiteDebito)) && (valor >= 0))
                return true;
            else
                return false;
        }

        public void Depositar(double valor, ContaCorrente conta)
        {
            conta.saldo += valor;
            conta.registroMovimentacoes[qtdMovimentacoes] = $"Depósito na {conta}: R$ {valor.ToString("F")} | {DateTime.Now}";
            conta.qtdMovimentacoes++;
        }

        public string ConsultarSaldo(ContaCorrente conta)
        {
            return $"Saldo atual: {conta.saldo}";
        }

        public void TransferirPara(ContaCorrente contaOrigem, ContaCorrente contaDestino, double valor)
        {
            contaOrigem.saldo -= valor;
            contaDestino.saldo += valor;
        }

        public bool TransferenciaPermitida(double valor)
        {
            if (valor <= saldo)
                return true;
            else
                return false;
        }
    }
}
