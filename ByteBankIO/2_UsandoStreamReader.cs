using ByteBankIO;

// 'partial' permite que a classe seja dividida em vários arquivos. É uma palavra-chave que permite dividir a definição de uma classe, struct ou interface em vários arquivos. Isso é útil para organizar o código, especialmente em projetos grandes, onde diferentes partes da classe podem ser mantidas em arquivos separados. No exemplo acima, a classe 'Program' é marcada como 'partial', o que significa que sua definição pode ser dividida em vários arquivos. Cada arquivo pode conter parte da implementação da classe, e o compilador irá combinar todas as partes durante a compilação para formar a classe completa.
partial class Program
{
    static void UsandoStreamReader()
    {
        // Nome do arquivo a ser lido
        var enderecoDoArquivo = "contas.txt";

        // 'using' é uma construção que garante que o objeto seja corretamente descartado após o uso. Ele é usado para gerenciar recursos, como arquivos, conexões de banco de dados ou fluxos de entrada/saída, garantindo que eles sejam liberados mesmo que ocorra uma exceção. No exemplo abaixo, o 'using' é utilizado para criar um bloco de código onde o objeto 'fluxoDeEntrada' e 'fs' são instanciados. Quando o bloco de código é concluído, seja normalmente ou devido a uma exceção, os objetos serão automaticamente descartados, liberando os recursos associados a eles.
        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            // StreamReader é uma classe que facilita a leitura de arquivos de texto. Ele fornece métodos convenientes para ler linhas, caracteres ou o conteúdo completo de um arquivo. No exemplo abaixo, um objeto 'leitor' do tipo StreamReader é criado, passando o fluxo do arquivo como parâmetro. O StreamReader é usado para ler o conteúdo do arquivo de forma mais eficiente e fácil do que ler byte por byte usando FileStream diretamente.
            var leitor = new StreamReader(fluxoDoArquivo);
            
            // var linha = leitor.ReadLine();
            // var texto = leitor.ReadToEnd();
            // var numero = leitor.Read();

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                var contaCorrente = ConverterStringParaContaCorrente(linha);

                var msg = $"{contaCorrente.Titular.Nome} : Conta número {contaCorrente.Numero}, ag {contaCorrente.Agencia}, Saldo {contaCorrente.Saldo}";
                Console.WriteLine(msg);
            }
        }
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        var campos = linha.Split(','); // O método Split é usado para dividir uma string em um array de substrings com base em um delimitador específico. No exemplo acima, a string 'linha' é dividida em partes usando a vírgula (',') como delimitador. O resultado é um array de strings chamado 'campos', onde cada elemento contém uma parte da string original que estava separada por vírgulas. Por exemplo, se a linha for "123,456,789.00,João Silva", o array 'campos' terá os seguintes valores: campos[0] = "123", campos[1] = "456", campos[2] = "789.00", campos[3] = "João Silva".

        var agencia = campos[0];
        var numero = campos[1];
        var saldo = campos[2].Replace('.', ','); // O método Replace é usado para substituir todas as ocorrências de um caractere ou sequência de caracteres por outro caractere ou sequência de caracteres. No exemplo acima, o método Replace é aplicado à string 'campos[2]', que contém o valor do saldo. Ele substitui todos os pontos ('.') por vírgulas (','). Isso é necessário porque, em algumas culturas, o separador decimal é a vírgula em vez do ponto. Portanto, se o saldo for representado como "789.00", ele será convertido para "789,00" para garantir que seja interpretado corretamente como um número decimal.
        var nomeTitular = campos[3];

        var agenciaComInt = int.Parse(agencia); // O método int.Parse é usado para converter uma string em um número inteiro. No exemplo acima, a string 'agencia' é convertida para um inteiro usando int.Parse. Se a string contiver um valor numérico válido, ele será convertido para o tipo int. Por exemplo, se 'agencia' for "123", o resultado de int.Parse(agencia) será o número inteiro 123. Se a string não puder ser convertida para um número inteiro (por exemplo, se contiver caracteres não numéricos), uma exceção será lançada.
        var numeroComInt = int.Parse(numero);
        var saldoComDouble = double.Parse(saldo);
        var titular = new Cliente();
        titular.Nome = nomeTitular;

        var resultado = new ContaCorrente(agenciaComInt, numeroComInt);
        resultado.Depositar(saldoComDouble);
        resultado.Titular = titular;
        return resultado;
    }
}