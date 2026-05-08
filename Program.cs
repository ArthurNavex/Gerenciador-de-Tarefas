using System;
using System.Collections.Generic;

namespace SistemaTarefas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            string tasks;
            List<Usuario> userList = new List<Usuario>();


            while (true)
            {
                Console.WriteLine("========== Bem Vindo! ==========");
                Console.WriteLine("");
                Console.WriteLine("[1] Cadastrar Usuario");
                Console.WriteLine("[2] Lista de Usuarios");
                Console.WriteLine("[3] Sair do Sistema");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Cadastrar usuário: ");
                    userList.Add(new Usuario { nomes = Console.ReadLine() });
                    Console.WriteLine("Usuario Adicionado!");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Lista de Usuarios: ");
                    foreach (Usuario users in userList)
                    {
                        Console.WriteLine(users.nomes);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Qual ação você deseja executar?: ");
                    int choiceUser;
                    Console.WriteLine("[1] Ver tarefas dos usuarios");
                    Console.WriteLine("[2] Adicionar tarefas para usuario");
                    Console.WriteLine("[3] Voltar");
                    choiceUser = int.Parse(Console.ReadLine());

                    string name;
                    Usuario user = null;
                    
         
                    if (choiceUser == 1)
                    {
                        Console.Write("Você quer ver as tarefas de qual usuario?: ");
                        name = Console.ReadLine();
                        user = userList.Find(u =>  u.nomes == name);
                        Console.WriteLine($"Voce selecionou o usuario: {user.nomes}");
                        Console.WriteLine(" ");
                        if (user.Tarefas.Count() == 0) 
                        {
                            Console.WriteLine($"{user.nomes} não possui tarefas");
                            Console.WriteLine(" ");
                        }
                        else
                        {
                            Console.WriteLine($"Tarefas de {user.nomes}: ");
                            for (int i = 0; i < user.Tarefas.Count(); i++) 
                            {
                                Tarefa task = user.Tarefas[i];
                                string status = task.Concluida ? "- (Concluida)" : "- (Não Concluida)";
                                Console.WriteLine($"[{i + 1}] {task.Descricao} {status}");
                                Console.WriteLine("");
                                Console.WriteLine("Qual ação você deseja executar?");
                            }
                            Console.WriteLine("[1] Marcar tarefa como concluida");
                            Console.WriteLine("[2] Voltar");
                            int acao = int.Parse(Console.ReadLine());

                            while (true)
                            {
                                if (acao == 1)
                                {
                                    int num;
                                    Console.WriteLine("Qual tarefa você quer marcar como concluida?");
                                    Console.Write("Digite o número da tareafa: ");
                                    num = int.Parse(Console.ReadLine()) - 1;
                                    if (num >= 0 && num < user.Tarefas.Count)
                                    {
                                        user.Tarefas[num].Concluida = true;
                                        Console.WriteLine("Tarefa marcada como concluida!");
                                        Console.WriteLine(" ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Essa tarefa não existe!");
                                        Console.WriteLine(" ");
                                    }
                                    break;
                                }
                                else if (acao == 2)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Opção invalida!");
                                    continue;
                                }
                            }
                        }
                    }
                    else if (choiceUser == 2)
                    {             
                        Console.Write("Para qual usuario voce quer adicionar uma tarefa?: ");
                        name = Console.ReadLine();
                        user = userList.Find(u =>  u.nomes == name);
                        Console.WriteLine($"Voce selecionou o usuario: {user.nomes}");

                        if (user != null)
                        {
                            Console.Write("Adicionar Tarefa: ");
                            tasks = Console.ReadLine();
                            user.Tarefas.Add(new Tarefa { Descricao = tasks });
                            Console.WriteLine(" ");
                        }
                        else
                        {
                            Console.WriteLine("Usuario não encontrado");
                            Console.WriteLine(" ");
                        }
                    }
                    else if (choiceUser == 3)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Escolha uma das opções disponíveis!");
                    }
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Escolha uma das opções!");
                }
            }
            Console.WriteLine("Voce saiu do sistema!");
        }
    }
}