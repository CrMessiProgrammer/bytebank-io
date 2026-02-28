// 'partial' permite que a classe seja dividida em vários arquivos. É uma palavra-chave que permite dividir a definição de uma classe, struct ou interface em vários arquivos. Isso é útil para organizar o código, especialmente em projetos grandes, onde diferentes partes da classe podem ser mantidas em arquivos separados. No exemplo acima, a classe 'Program' é marcada como 'partial', o que significa que sua definição pode ser dividida em vários arquivos. Cada arquivo pode conter parte da implementação da classe, e o compilador irá combinar todas as partes durante a compilação para formar a classe completa.
partial class Program
{
    static void UsarStreamDeEntrada()
    {
        // 'using' é uma construção que garante que o objeto seja corretamente descartado após o uso. Ele é usado para gerenciar recursos, como arquivos, conexões de banco de dados ou fluxos de entrada/saída, garantindo que eles sejam liberados mesmo que ocorra uma exceção. No exemplo abaixo, o 'using' é utilizado para criar um bloco de código onde o objeto 'fluxoDeEntrada' e 'fs' são instanciados. Quando o bloco de código é concluído, seja normalmente ou devido a uma exceção, os objetos serão automaticamente descartados, liberando os recursos associados a eles.
        // O Console.OpenStandardInput() retorna um Stream de entrada que representa a entrada padrão do console. Ele permite ler os dados que o usuário digita no console. O método OpenStandardInput() é útil quando você deseja ler dados diretamente do console usando um Stream, em vez de usar métodos como Console.ReadLine() ou Console.ReadKey(). Ele é especialmente útil quando você deseja processar os dados de entrada de forma mais flexível, como ler bytes ou usar um buffer para ler grandes quantidades de dados.
        using (var fluxoDeEntrada = Console.OpenStandardInput())
        using (var fs = new FileStream("entradaConsole.txt", FileMode.Create)) // Cria um arquivo chamado "entradaConsole.txt" para armazenar os dados lidos do console. O FileMode.Create indica que o arquivo será criado se não existir ou sobrescrito se já existir.
        {
            // O buffer é um array de bytes que serve como uma área de armazenamento temporária para os dados lidos do console. Ele é usado para armazenar os bytes lidos antes de serem gravados no arquivo. O tamanho do buffer é definido como 1024 bytes (1 KB), o que significa que ele pode armazenar até 1024 bytes de dados lidos do console antes de precisar ser esvaziado e gravado no arquivo.
            var buffer = new byte[1024]; // 1kb

            while (true)
            {
                // O método Read() do fluxo de entrada é usado para ler os dados do console e armazená-los no buffer. Ele lê até 1024 bytes de dados (ou menos, se houver menos dados disponíveis) e retorna o número de bytes realmente lidos. O método Read() bloqueia a execução do programa até que haja dados disponíveis para leitura, ou seja, até que o usuário digite algo no console e pressione Enter. O número de bytes lidos é armazenado na variável bytesLidos, que é usada posteriormente para gravar os dados no arquivo.
                var bytesLidos = fluxoDeEntrada.Read(buffer, 0, 1024); // Lê os dados do console e armazena no buffer. O método Read() bloqueia a execução do programa até que haja dados disponíveis para leitura, ou seja, até que o usuário digite algo no console e pressione Enter.
                fs.Write(buffer, 0, bytesLidos); // Grava os bytes lidos do console no arquivo "entradaConsole.txt". O método Write() escreve os bytes do buffer no arquivo, começando na posição 0 e escrevendo o número de bytes especificado por bytesLidos.
                fs.Flush(); // O método Flush() é usado para garantir que todos os dados gravados no arquivo sejam realmente escritos no disco. Ele esvazia o buffer de escrita, forçando a gravação dos dados pendentes no arquivo. Isso é importante para garantir que os dados sejam salvos corretamente, especialmente quando o programa pode ser encerrado ou quando há uma grande quantidade de dados a serem gravados. Sem chamar Flush(), os dados podem permanecer no buffer e não serem gravados no arquivo até que o buffer seja cheio ou o programa seja encerrado.
                Console.WriteLine($"Bytes lidos na console: {bytesLidos}");
            }

        }
    }
}
