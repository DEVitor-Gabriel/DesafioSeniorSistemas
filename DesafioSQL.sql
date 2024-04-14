SELECT 
    Numero AS NumeroProcesso,
    'Conta a Pagar' AS Tipo,
    Fornecedor.Nome AS NomeFornecedor,
    DataVencimento,
    NULL AS DataPagamento,
    (Valor - Desconto + Acrescimo) AS ValorLiquido
FROM 
    ContasAPagar
INNER JOIN 
    Pessoas AS Fornecedor ON ContasAPagar.CodigoFornecedor = Fornecedor.Codigo

UNION ALL

SELECT 
    Numero AS NumeroProcesso,
    'Conta Paga' AS Tipo,
    Fornecedor.Nome AS NomeFornecedor,
    DataVencimento,
    DataPagamento,
    (Valor - Desconto + Acrescimo) AS ValorLiquido
FROM 
    ContasPagas
INNER JOIN 
    Pessoas AS Fornecedor ON ContasPagas.CodigoFornecedor = Fornecedor.Codigo;
