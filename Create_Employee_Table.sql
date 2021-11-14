Create TABLE employee (

    employee_id serial primary key,
    first_name varchar(30),
    last_name varchar(30),
    hire_date date,
    job_title varchar(30),
    shop_id integer references coffee_shop(shop_id)










)