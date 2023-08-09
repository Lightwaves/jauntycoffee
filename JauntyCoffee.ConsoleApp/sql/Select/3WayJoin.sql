select shop_name, coffee_name, company_name as supplier_company from 
Coffee_Shop 
join Coffee on Coffee_Shop.shop_id = Coffee.shop_id
join Supplier on Coffee.supplier_id = Supplier.supplier_id