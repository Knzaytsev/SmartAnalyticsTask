select SalespersonID as SalespersonPersonID, count(orderID) as OrderCount from Orders 
where year(OrderDate) = 2013
group by SalespersonID