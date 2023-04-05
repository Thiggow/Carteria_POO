namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Carteira> carteiras = new List<Carteira>();
            string entrada;
            do
            {
                Console.WriteLine("Digite 1 para criar conta:");
                Console.WriteLine("Digite 2 para Acessar conta:");
                Console.WriteLine("Digite 3 para Listar Todas as contas:");
                Console.WriteLine("Digite 4 para sair:");

                entrada = Console.ReadLine();

                switch (entrada)
                {
                    case "1":
                        Carteira novaCarteira = CriarConta();
                        carteiras.Add(novaCarteira);
                        break;
                    case "3":
                        foreach (var c in carteiras)
                            Console.WriteLine(c.Dono + " Saldo: R$" + c.Saldo);
                        break;
                    case "2":
                        Console.WriteLine("Entre com Nome de acesso:");
                        string dono = Console.ReadLine();
                        Carteira catual = carteiras.FirstOrDefault(o => o.Dono == dono);
                        if (catual != null)
                            AcessarCarteira(catual, carteiras);
                        else
                            Console.WriteLine("Acesso negado!");
                        break;
                }
            } while (entrada != "4");
        }


        public static Carteira CriarConta()
        {
            string Nome; double Valor;
            Console.WriteLine("Entre com nome do Titular:");
            Nome = Console.ReadLine();
            Console.WriteLine("Entre com valor do 1 deposito:");
            Valor = Convert.ToDouble(Console.ReadLine());
            Carteira carteira = new Carteira();
            carteira.Dono = Nome;
            carteira.Depositar(Valor);
            return carteira;
        }


        public static void AcessarCarteira(Carteira carteira, List<Carteira> dados)
        {
            Console.WriteLine("Digite 1 para transferir");
            Console.WriteLine("Digite 2 para verificar saldo");
            Console.WriteLine("Digite 3 para sacar");
            Console.WriteLine("Digite 4 para depositar");
            string entrada = Console.ReadLine();

            switch (entrada)
            {
                case "1":
                    Transferir(carteira, dados);

                    break;
                case "2":
                    VerificarSaldo(carteira, dados);

                    break;
                case "3":
                    Sacar(carteira, dados);

                    break;
                case "4":
                    Depositar(carteira, dados);

                    break;
            }
        }


        public static void Depositar(Carteira carteira, List<Carteira> dados)
        {
            Console.WriteLine("Valor que deseja depositar: ");
            carteira.Depositar(Convert.ToDouble(Console.ReadLine()));

            Console.WriteLine("Depósito realizado com sucesso!");
        }


        public static void Sacar(Carteira carteira, List<Carteira> dados)
        {
            Console.WriteLine("Valora que deseja sacar: ");

            if (carteira.Sacar(Convert.ToDouble(Console.ReadLine())))
            {
                Console.WriteLine("Saque realizado com sucesso!");
            }
            else
                Console.WriteLine("Erro. Valor de saque maior que seu saldo.");
        }


        public static void VerificarSaldo(Carteira carteira, List<Carteira> dados)
        {
            Console.WriteLine("Seu saldo atual: R$" + carteira.Saldo);
        }


        public static void Transferir(Carteira carteira, List<Carteira> dados)
        {
            Console.WriteLine("Entre com a carteira de destino");
            string dono = Console.ReadLine();

            Carteira destino = dados.FirstOrDefault(o => o.Dono == dono);
            if (destino == null)
            {
                Console.WriteLine("Destinatario invalido");
                return;
            }

            Console.WriteLine("Entre com valor:");
            double valor = Convert.ToDouble(Console.ReadLine());
            bool tOk = carteira.Transferir(destino, valor);

            if (tOk)
                Console.WriteLine("Transferencia realizada com sucesso! Seu saldo atual: R$" + carteira.Saldo);
            else
                Console.WriteLine("ERRO- transacao abortada!");
        }


    }
}