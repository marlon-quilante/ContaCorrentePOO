namespace ContaCorrentePOO
{
    internal class ContaCorrente
    {
        public int numero = 0;
        public double saldo = 0.0F;
        public double limiteDebito = 0.0F;
        public string[] registroMovimentacoes = new string[50];
        public int qtdMovimentacoes = 0;

        public void Saque(double valor, ContaCorrente conta)
        {
            saldo -= valor;
            registroMovimentacoes[qtdMovimentacoes] = $"Saque na {conta}: R$ {valor.ToString("F")} | {DateTime.Now}";
            qtdMovimentacoes++;
        }

        public bool SaquePermitido(double valor)
        {
            if (valor <= saldo + limiteDebito)
                return true;
            else
            return false;
        }

        public void Deposito(double valor, ContaCorrente conta)
        {
            saldo += valor;
            registroMovimentacoes[qtdMovimentacoes] = $"Depósito na {conta}: R$ {valor.ToString("F")} | {DateTime.Now}";
            qtdMovimentacoes++;
        }

        public string ConsultaSaldo()
        {
            return $"Saldo atual: {saldo}";
        }

        public void TransferirPara(double valor, ContaCorrente conta)
        {
            saldo -= valor;
            conta.saldo += valor;
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
