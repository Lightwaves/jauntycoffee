Create TABLE Coffee(
    coffee_id serial primary key,
    shop_id serial,
    supplier_id serial,
    coffee_name varchar(30),
    price_per_pound NUMERIC(5,2)
    foreign key(shop_id) references Coffee_Shop(shop_id)
    foreign key(supplier_id) references Supplier(supplier_id)





)