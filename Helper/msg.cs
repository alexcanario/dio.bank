using System;

namespace dio.bank.helper {
    public static class msg {
        public static void AvisoRetornoMenu(string operacao = ""){
            Console.WriteLine($"{operacao} Pressione uma tecla para retornar ao menu principal");
            Console.ReadKey();
        }
    }
}