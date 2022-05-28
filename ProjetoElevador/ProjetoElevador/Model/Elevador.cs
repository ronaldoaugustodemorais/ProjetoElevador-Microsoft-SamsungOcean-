using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElevador.Model
{
    public class Elevador
    {        
        //andarAtual = 0 (terreo)
        //totalAndares = X (informado pelo usuario; desconsiderando o terreo (0))
        //capacidadeElevador = Y (informado pelo usuario; carga maxima de passageiros dentro do Elevador; numero de pessoas)
        //qtdePassageiros = 0 (quantos passageiros estao no Elevador)     

        //METODOS
        //inicializar: entrada: capacidadeElevador; totalAndares;
        //                  sempre inicializa no terreo e vazio
        //entrar: acrescentar 1 pessoa no Elevador (se houver espaco)
        //sair: remover 1 pessoa do Elevador (se houver alguem dentro dele)
        //subir: subir 1 andar (nao subir se ja estiver no ultimo andar)
        //descer: descer 1 andar (nao descer se ja estiver no terreo)

        public int totalAndares { get; set; }
        public int capacidadeElevador { get; set; }
        public int qtdePassageiros { get; set; }
        public int andarAtual { get; set; }

        public Elevador()
        {
            //Tela de Boas-vindas e Cadastro das informacoes pelo Usuario
            Console.WriteLine("===== Bem-vindo ao Elevador =====");

            //capacidadeElevador => Representa o numero maximo de pessoas que podem estar dentro do Elevador
            Console.Write("=> Por favor, digite a capacidade maxima (total de pessoas dentro do Elevador): ");
            capacidadeElevador = Convert.ToInt32(Console.ReadLine());

            //totalAndares => Sera o numero maximo de Andares que o Elevador podera subir, nao sendo possivel exceder este numero
            Console.Write("=> Por favor, digite quantos Andares possui este predio: ");
            totalAndares = Convert.ToInt32(Console.ReadLine());
            
            //andarAtual => Nos informa qual o estado atual do Elevador, em que Andar ele esta localizado
            andarAtual = 0;
            
            //qtdePassageiros => E' o numero atualizado de passageiros dentro do Elevador
            qtdePassageiros = 0;
                       
            Console.WriteLine("A capacidade Maxima de Pessoas no Elevador e' de: " + capacidadeElevador + " pessoa(s)");
            Console.WriteLine("O total de Andares foi definido para: " + totalAndares + " andares.");
            Console.Write("Pressione qualquer tecla para Continuar...");
            
            //ReadKey().Key != null => Verifica se alguma tecla foi pressionada, ou seja, esta' aguardando a interacao do usuario com o teclado, para avancar ao Menu Principal
            if (Console.ReadKey().Key != null)
            {
                Inicializar();
            }
        }
        public void Inicializar()
        {
            //Console.Clear() => Comando responsavel por limpar a tela (deixar um ambiente mais agradavel ao Usuario)
            Console.Clear();
            //Menu Principal de Opcoes para o Usuario. Sempre sera o "ponto de partida" das Interacoes com o Usuario
            Console.WriteLine("===== MENU PRINCIPAL (CORREDOR) =====");
            Console.WriteLine("( 1 ) Entrar no Elevador");
            Console.WriteLine("( 2 ) Sair do Elevador");
            Console.WriteLine("( 3 ) Consultar Elevador");
            Console.WriteLine("( 4 ) Subir para o Proximo Andar");
            Console.WriteLine("( 5 ) Descer para o Andar anterior");
            Console.WriteLine("( 0 ) Desligar o Elevador");
            Console.Write("=> Por favor, digite a opcao que deseja: ");
            //Ao receber a opcao digitada pelo usuario, convertemos em um Inteiro e validamos por meio do switch{case}
            int opcao = Convert.ToInt32(Console.ReadLine());
            //validacao da opcao escolhida pelo usuario
            switch (opcao)
            {
                case 1:
                    EntrarElevador();
                    break;
                case 2:
                    SairElevador();
                    break;
                case 3:
                    Consultar();
                    break;
                case 4:
                    SubirAndar();
                    break;
                case 5:
                    DescerAndar();
                    break;
                case 0:
                    DesligarElevador();
                    break;
                default:
                    //Se o usuario nao escolher nenhuma das opcoes informadas anteriormente, ele recebera essa tela de erro, e o levara novamente ao Menu Principal
                    Console.WriteLine("Opcao Invalida, inicie novamente o Elevador.");
                    Console.Write("Pressione qualquer tecla para continuar...");
                    if (Console.ReadKey().Key != null)
                    {
                        Inicializar();
                    }
                    break;
            }
            
        }
        public void EntrarElevador()
        {
            Console.Clear();
            //Ao Entrar no Elevador, precisamos verificar a quantidade de Passageiros, para evitar superlotacao
            if (qtdePassageiros < capacidadeElevador)
            {
                if(qtdePassageiros == 0)
                {
                    Console.WriteLine("Voce esta dentro do Elevador, por enquanto sozinho(a)");                  
                }
                else
                {
                    Console.WriteLine("Voce esta dentro do Elevador, com mais " + qtdePassageiros + " pessoa(s)");                    
                }     
                //Ao confirmar a disponibilidade de vaga, incrementamos o qtdePassageiros e verificamos/informamos o Andar que o Elevador esta'
                qtdePassageiros++;
                
                if (andarAtual == 0)
                {
                    Console.WriteLine("Voce esta no Terreo. Favor escolher uma opcao");
                }
                else
                {
                    Console.WriteLine("Voce esta no " + andarAtual + " Andar. Favor escolher uma opcao");
                }
                //Menu de Opcoes, uma vez que o Passageiro ja esta' dentro do Elevador
                Console.WriteLine("\n===== MENU OPCOES (CABINE) =====");
                Console.WriteLine("( 1 ) Subir para o proximo andar");
                Console.WriteLine("( 2 ) Descer para o andar anterior");
                Console.WriteLine("( 3 ) Sair do Elevador");
                Console.Write("=> Por favor, digite a opcao que deseja: ");
                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        SubirAndar();
                        break;
                    case 2:
                        DescerAndar();
                        break;
                    case 3:
                        SairElevador();
                        break;
                    default:
                        Console.WriteLine("Opcao Invalida, inicie novamente o Elevador.");
                        Console.Write("Pressione qualquer tecla para continuar...");
                        if (Console.ReadKey().Key != null)
                        {
                            Inicializar();
                        }
                        break;
                }
            }
            else
            {
                //Se nao houver mais vagas no Elevador, o Usuario recebera' uma mensagem de erro, informando isto.
                Console.WriteLine("O Elevador esta cheio, sera necessario aguardar alguem descer.");
                Console.Write("Pressione 0(zero) para aguardar o proximo Elevador: ");
                int opcao = Convert.ToInt32(Console.ReadLine());
                switch(opcao)
                {
                    case 0:
                        Inicializar();
                        break;
                }
            }            
        }
        public void SairElevador()
        {
            Console.Clear();
            if(qtdePassageiros > 0)
            {
                qtdePassageiros--;
                Console.WriteLine("Saiu 1 passageiro, restando: " + qtdePassageiros + " pessoas dentro do Elevador");
                Console.Write("Pressione qualquer tecla para continuar...");
                if (Console.ReadKey().Key != null)
                {
                    Inicializar();
                }
            }
            else
            {
                Console.WriteLine("Nao possui mais Passageiros no Elevador.");
                Console.Write("Pressione qualquer tecla para continuar...");
                if (Console.ReadKey().Key != null)
                {
                    Inicializar();
                }
            }
        }        
        public void SubirAndar()
        {
            Console.Clear();
            if (andarAtual >= totalAndares)
            {
                Console.WriteLine("Opa! Voce nao pode subir mais nenhum andar, pois ja esta' no " + andarAtual + " esimo andar (ultimo andar).");
                Console.WriteLine("\n===== MENU OPCOES =====");               
                Console.WriteLine("( 1 ) Descer para o andar anterior");
                Console.WriteLine("( 2 ) Sair do Elevador");
                Console.Write("=> Por favor, digite a opcao que deseja: ");
                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {                    
                    case 1:
                        DescerAndar();
                        break;
                    case 2:
                        SairElevador();
                        break;
                    default:
                        Console.WriteLine("Opcao Invalida, inicie novamente o Elevador.");
                        Console.Write("Pressione qualquer tecla para continuar...");
                        if (Console.ReadKey().Key != null)
                        {
                            Inicializar();
                        }
                        break;
                }
            }
            else
            {
                andarAtual++;
                Console.WriteLine("Ok. Voce acaba de subir e chegar no proximo Andar: " + andarAtual);
                Console.Write("Pressione qualquer tecla para continuar...");
                if (Console.ReadKey().Key != null)
                {
                    Inicializar();
                }                
            }            
        }
        public void DescerAndar()
        {
            Console.Clear();
            if (andarAtual == 0)
            {
                Console.WriteLine("Opa! Voce nao pode descer mais nenhum andar, pois ja esta' no Terreo");
                Console.WriteLine("\n===== MENU OPCOES =====");
                Console.WriteLine("( 1 ) Subir para o proximo andar");
                Console.WriteLine("( 2 ) Sair do Elevador");
                Console.Write("=> Por favor, digite a opcao que deseja: ");
                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        SubirAndar();
                        break;
                    case 2:
                        SairElevador();
                        break;
                    default:
                        Console.WriteLine("Opcao Invalida, inicie novamente o Elevador.");
                        Console.Write("Pressione qualquer tecla para continuar...");
                        if (Console.ReadKey().Key != null)
                        {
                            Inicializar();
                        }
                        break;
                }
            }
            else
            {
                andarAtual--;
                Console.WriteLine("Ok. Voce acaba de descer e chegar no Andar: " + andarAtual);
                Console.Write("Pressione qualquer tecla para continuar...");
                if (Console.ReadKey().Key != null)
                {
                    Inicializar();
                }
            }
        }
        public void DesligarElevador()
        {
            Console.Clear();
            if (qtdePassageiros > 0)
            {
                Console.WriteLine("Nao e' possivel Desligar o Elevador com Passageiros dentro.");
                Console.Write("=> Por favor digitar ( 1 ) Para Retornar ao Menu Anterior: ");
                int opcao = Convert.ToInt32(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Inicializar();
                        break;
                    default:
                        Console.WriteLine("Opcao invalida, voce sera Redirecionado para o Menu Principal.");
                        Console.Write("Pressione qualquer tecla para continuar...");
                        if (Console.ReadKey().Key != null)
                        {
                            Inicializar();
                        }                        
                        break;
                }
            }
            if (andarAtual != 0)
            {
                Console.WriteLine("Nao e' possivel Desligar o Elevador sem que ele esteja no Andar 0 (Terreo)");
                Console.WriteLine("Voce sera Redirecionado para o Menu Principal.");
                Console.Write("Pressione qualquer tecla para continuar...");
                if (Console.ReadKey().Key != null)
                {
                    Inicializar();
                }
            }
        }
        public void Consultar()
        {
            Console.Clear();
            Console.WriteLine("\n=== MENU CONSULTA ===");
            Console.WriteLine("( 1 ) Quantidade Passageiros");
            Console.WriteLine("( 2 ) Qual Andar esta' o Elevador");
            Console.Write("=> Por favor, digite qual opcao deseja Consultar: ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("No momento existem " + qtdePassageiros + " Passageiros dentro do Elevador");
                    if(qtdePassageiros == capacidadeElevador)
                    {
                        Console.WriteLine("E no momento esta' cheio, pois sua capacidade maxima e' de: " + capacidadeElevador + " pessoas");
                    }
                    Console.Write("Pressione qualquer tecla para continuar...");
                    if (Console.ReadKey().Key != null)
                    {
                        Inicializar();
                    }
                    break;
                case 2:
                    Console.WriteLine("No momento o Elevador esta no Andar " +andarAtual);
                    Console.Write("Pressione qualquer tecla para continuar...");
                    if (Console.ReadKey().Key != null)
                    {
                        Inicializar();
                    }
                    break;
                default:
                    Console.WriteLine("Opcao Invalida, inicie novamente o Elevador.");
                    Console.Write("Pressione qualquer tecla para continuar...");
                    if(Console.ReadKey().Key != null)
                    {
                        Inicializar();
                    }
                    break;
            }
        }
    }
}
