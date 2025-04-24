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
            conta.saldo -= valor;
            
            conta.registroMovimentacoes[qtdMovimentacoes] = $"Operação: Saque | Valor: R$ {valor.ToString("F")} " +
                $"| Saldo: {conta.saldo.ToString("F2")} | Data: {DateTime.Now}";
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
            
            conta.registroMovimentacoes[qtdMovimentacoes] = $"Operação: Depósito | Valor: R$ {valor.ToString("F")} " +
                $"| Saldo: {conta.saldo.ToString("F2")} | Data: {DateTime.Now}";
            conta.qtdMovimentacoes++;
        }

        public void Transferir(ContaCorrente contaOrigem, ContaCorrente contaDestino, double valor)
        {
            contaOrigem.saldo -= valor;
            contaDestino.saldo += valor;

            contaOrigem.registroMovimentacoes[qtdMovimentacoes] = $"Operação: Transferência enviada | Valor: R$ {valor.ToString("F")} " +
                $"| Saldo: {contaOrigem.saldo.ToString("F2")} | Data: {DateTime.Now}";

            contaDestino.registroMovimentacoes[qtdMovimentacoes] = $"Operação: Transferência recebida | Valor: R$ {valor.ToString("F")} " +
                $"| Saldo: {contaDestino.saldo.ToString("F2")} | Data: {DateTime.Now}";

            contaOrigem.qtdMovimentacoes++;
            contaDestino.qtdMovimentacoes++;
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
