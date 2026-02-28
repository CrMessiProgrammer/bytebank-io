using System.Text;

// 'partial' permite que a classe seja dividida em vários arquivos. É uma palavra-chave que permite dividir a definição de uma classe, struct ou interface em vários arquivos. Isso é útil para organizar o código, especialmente em projetos grandes, onde diferentes partes da classe podem ser mantidas em arquivos separados. No exemplo acima, a classe 'Program' é marcada como 'partial', o que significa que sua definição pode ser dividida em vários arquivos. Cada arquivo pode conter parte da implementação da classe, e o compilador irá combinar todas as partes durante a compilação para formar a classe completa.
partial class Program
{
    static void CriarArquivo()
    {
        // Nome do arquivo a ser criado
        var caminhoNovoArquivo = "contasExportadas.csv";

        // 'using' é uma construção que garante que o objeto seja corretamente descartado após o uso. Ele é usado para gerenciar recursos, como arquivos, conexões de banco de dados ou fluxos de entrada/saída, garantindo que eles sejam liberados mesmo que ocorra uma exceção. No exemplo abaixo, o 'using' é utilizado para criar um bloco de código onde o objeto 'fluxoDeEntrada' e 'fs' são instanciados. Quando o bloco de código é concluído, seja normalmente ou devido a uma exceção, os objetos serão automaticamente descartados, liberando os recursos associados a eles.
        using (var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            var contaComoString = "456,78945,4785.40,Gustavo Santos";
            var encoding = Encoding.UTF8; // UTF-8 é um padrão de codificação de caracteres que pode representar todos os caracteres do conjunto Unicode. Ele é amplamente utilizado para garantir a compatibilidade entre diferentes sistemas e linguagens de programação, permitindo que textos sejam corretamente interpretados e exibidos, independentemente do idioma ou dos caracteres especiais presentes. No exemplo acima, a variável 'encoding' é definida como 'Encoding.UTF8', indicando que a codificação UTF-8 será utilizada para converter a string 'contaComoString' em bytes antes de escrevê-la no arquivo.
            var bytes = encoding.GetBytes(contaComoString); // O método 'GetBytes' da classe 'Encoding' é utilizado para converter uma string em um array de bytes, de acordo com a codificação especificada. No exemplo acima, a string 'contaComoString' é convertida em um array de bytes usando a codificação UTF-8 definida na variável 'encoding'. Esse array de bytes pode então ser escrito em um arquivo ou transmitido por uma rede, garantindo que os caracteres sejam corretamente representados e interpretados quando lidos posteriormente.

            fluxoDoArquivo.Write(bytes, 0, bytes.Length); // O método 'Write' da classe 'FileStream' é utilizado para escrever um array de bytes em um arquivo. Ele recebe três parâmetros: o array de bytes a ser escrito, o índice inicial no array a partir do qual os bytes serão escritos, e o número de bytes a serem escritos. No exemplo acima, o método 'Write' é chamado para escrever o array de bytes 'bytes' no arquivo representado por 'fluxoDoArquivo', começando do índice 0 e escrevendo a quantidade total de bytes presente no array (bytes.Length). Isso resulta na escrita da string original, convertida em bytes, no arquivo especificado.
        }
    }

    static void CriarArquivoComWriter()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";

        using (var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (var escritor = new StreamWriter(fluxoDoArquivo))
        {
            escritor.Write("456,65465,456.0,Pedro");
        }
    }

    static void TestaEscrita()
    {
        var caminhoNovoArquivo = "teste.txt";

        using (var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (var escritor = new StreamWriter(fluxoDoArquivo))
        {
            for (var i = 0; i < 1000000; i++)
            {
                escritor.WriteLine($"Linha {i}");
                escritor.Flush(); // Despeja o buffer para o Stream!
                Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter...");
                Console.ReadLine();
            }
        }
    }
}