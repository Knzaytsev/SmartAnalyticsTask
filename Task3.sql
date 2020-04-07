select OrderID, sum(UnitPrice * Quantity) as TotalCost from OrderLines
group by OrderID
having sum(UnitPrice * Quantity) > 25000
order by TotalCost desc