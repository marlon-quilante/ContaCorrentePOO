namespace ContaCorrentePOO
{
    public class Movimentacao
    {
        public double valor = 0.0F;
        public string tipo = "";
        public DateTime dataHora = new DateTime();

        public string RegistroMovimentacao(ContaCorrente conta)
        {
            return $"Operação: {tipo} | Valor: R$ {valor.ToString("F")} " +
                            $"| Saldo: {conta.saldo.ToString("F2")} | Data: {dataHora}";
        }
    }
}
