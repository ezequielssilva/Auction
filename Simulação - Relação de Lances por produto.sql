SELECT 
    PS.Name AS "Nome do Comprador", 
    P.Name AS "Nome do Produto", 
    N.[Value] AS "Valor do Lance"
FROM Negotiation N
INNER JOIN Product P
    ON P.Id = N.ProductId
INNER JOIN Person PS
    ON PS.Id = N.PersonId
WHERE P.Id = 1
ORDER BY N.[Value] DESC
