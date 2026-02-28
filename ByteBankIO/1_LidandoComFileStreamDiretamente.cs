using System.Text;

// 'partial' permite que a classe seja dividida em vários arquivos. É uma palavra-chave que permite dividir a definição de uma classe, struct ou interface em vários arquivos. Isso é útil para organizar o código, especialmente em projetos grandes, onde diferentes partes da classe podem ser mantidas em arquivos separados. No exemplo acima, a classe 'Program' é marcada como 'partial', o que significa que sua definição pode ser dividida em vários arquivos. Cada arquivo pode conter parte da implementação da classe, e o compilador irá combinar todas as partes durante a compilação para formar a classe completa.
partial class Program
{
    static void LidandoComFileStreamDiretamente()
    {
        // Nome do arquivo a ser lido
        var enderecoDoArquivo = "contas.txt";

        // 'using' é uma construção que garante que o objeto seja corretamente descartado após o uso. Ele é usado para gerenciar recursos, como arquivos, conexões de banco de dados ou fluxos de entrada/saída, garantindo que eles sejam liberados mesmo que ocorra uma exceção. No exemplo abaixo, o 'using' é utilizado para criar um bloco de código onde o objeto 'fluxoDeEntrada' e 'fs' são instanciados. Quando o bloco de código é concluído, seja normalmente ou devido a uma exceção, os objetos serão automaticamente descartados, liberando os recursos associados a eles.
        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open, FileAccess.Read))
        {
            // 'buffer' é um array de bytes que serve como um espaço de armazenamento temporário para os dados lidos do arquivo. Ele é usado para armazenar os bytes lidos do arquivo antes de processá-los ou convertê-los em uma representação legível. No exemplo abaixo, o 'buffer' é criado com um tamanho de 1024 bytes (1KB), o que significa que ele pode armazenar até 1024 bytes de dados lidos do arquivo em cada iteração do loop. O número de bytes realmente lidos é armazenado na variável 'numeroDeBytesLidos', que é usada para determinar quantos bytes do buffer contêm dados válidos.
            var buffer = new byte[1024]; // 1KB
            var numeroDeBytesLidos = -1;

            while (numeroDeBytesLidos != 0)
            {
                // 'Read' é um método da classe 'FileStream' que lê um bloco de bytes do fluxo de entrada e os armazena em um buffer. Ele retorna o número de bytes lidos, ou 0 se o final do arquivo for alcançado. No exemplo abaixo, o método 'Read' é chamado dentro de um loop para ler continuamente os dados do arquivo até que o final seja alcançado (quando 'numeroDeBytesLidos' se torna 0). O buffer é preenchido com os bytes lidos, e a quantidade de bytes lidos é armazenada na variável 'numeroDeBytesLidos', que é usada para controlar o loop e determinar quantos bytes do buffer contêm dados válidos.
                numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                // Console.WriteLine($"Bytes lidos: {numeroDeBytesLidos}");
                EscreverBuffer(buffer, numeroDeBytesLidos);
            }
        }
        Console.ReadLine();
    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        var utf8 = new UTF8Encoding(); // UTF-8 é uma codificação de caracteres que representa texto usando uma sequência de bytes. Ela é amplamente utilizada para codificar caracteres Unicode, permitindo a representação de uma ampla variedade de caracteres de diferentes idiomas e símbolos. No exemplo abaixo, a classe 'UTF8Encoding' é usada para criar um objeto que pode ser utilizado para converter os bytes lidos do arquivo em uma string legível. O método 'GetString' é chamado para converter os bytes do buffer em uma string, especificando o número de bytes lidos para garantir que apenas os dados válidos sejam convertidos.

        var texto = utf8.GetString(buffer, 0, bytesLidos); // 'GetString' é um método da classe 'UTF8Encoding' que converte uma sequência de bytes em uma string usando a codificação UTF-8. Ele recebe um array de bytes, um índice de início e um número de bytes a serem convertidos. No exemplo abaixo, o método 'GetString' é chamado para converter os bytes lidos do buffer em uma string legível, especificando o número de bytes lidos para garantir que apenas os dados válidos sejam convertidos. O resultado é armazenado na variável 'texto', que pode ser exibida ou processada posteriormente.

        // public override string GetString(byte[] bytes, int index, int count);
        Console.Write(texto);

        //foreach (var meuByte in buffer)
        //{
        //    Console.Write(meuByte);
        //    Console.Write(" ");
        //}
    }
}