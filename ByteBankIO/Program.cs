using ByteBankIO;

// 'partial' permite que a classe seja dividida em vários arquivos. É uma palavra-chave que permite dividir a definição de uma classe, struct ou interface em vários arquivos. Isso é útil para organizar o código, especialmente em projetos grandes, onde diferentes partes da classe podem ser mantidas em arquivos separados. No exemplo acima, a classe 'Program' é marcada como 'partial', o que significa que sua definição pode ser dividida em vários arquivos. Cada arquivo pode conter parte da implementação da classe, e o compilador irá combinar todas as partes durante a compilação para formar a classe completa.
partial class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Digite o seu nome:");
        //string nome = Console.ReadLine();

        // O método WriteAllLines() da classe File é usado para escrever um array de strings em um arquivo. Ele recebe dois parâmetros: o caminho do arquivo onde as linhas serão escritas e o array de strings que contém as linhas a serem escritas. No exemplo acima, o método WriteAllLines() é utilizado para criar um arquivo chamado "contas.txt" e escrever as linhas "Linha 1", "Linha 2" e "Linha 3" nesse arquivo. Cada elemento do array de strings será escrito em uma linha separada no arquivo.
        var linhas = File.ReadAllLines("contas.txt");
        Console.WriteLine(linhas.Length);

        //foreach (var linha in linhas)
        //{
        //    Console.WriteLine(linha);
        //}

        // O método ReadAllBytes() da classe File é usado para ler todos os bytes de um arquivo e retornar um array de bytes. Ele recebe o caminho do arquivo como parâmetro e lê todo o conteúdo do arquivo, retornando-o como um array de bytes. No exemplo acima, o método ReadAllBytes() é utilizado para ler o conteúdo do arquivo "contas.txt" e armazená-lo em um array de bytes chamado bytesArquivo. Em seguida, o código imprime a quantidade de bytes presentes no arquivo usando a propriedade Length do array de bytes.
        var bytesArquivo = File.ReadAllBytes("contas.txt");
        Console.WriteLine($"Arquivo contas.txt possui {bytesArquivo.Length} bytes");

        // O método WriteAllText() da classe File é usado para escrever uma string em um arquivo. Ele recebe dois parâmetros: o caminho do arquivo onde a string será escrita e a string que contém o conteúdo a ser escrito. No exemplo acima, o método WriteAllText() é utilizado para criar um arquivo chamado "escrevendoComAClasseFile.txt" e escrever a string "Testando File.WriteAllText" nesse arquivo. Se o arquivo já existir, ele será sobrescrito com o novo conteúdo.
        File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText");

        Console.WriteLine("Aplicação Finalizada ...");
        Console.ReadLine();
    }
}