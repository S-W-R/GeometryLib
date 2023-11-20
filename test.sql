create table if not exists products
(
    product_id   int primary key,
    product_name varchar,
    some_data    varchar
);

create table if not exists categories
(
    category_id   int primary key,
    category_name varchar,
    some_data     varchar
);

create table if not exists product_categories
(
    product_id  int references products (product_id),
    category_id int references categories (category_id),
    primary key (product_id, category_id)
);

insert into products
values (1, 'apple', 'some info'),
       (2, 'banana', 'some food info'),
       (5, 'lumber', 'some construction materials'),
       (9, 'car', 'lada');

insert into categories
values (345, 'food', 'some interesting description'),
       (123, 'wood', 'some data'),
       (193, 'construction_materials', 'for construction'),
       (999, 'chemistry', 'yeah science!');

insert into product_categories
values (1, 345),
       (2, 345),
       (5, 123),
       (5, 193);

select p.product_name as Product, c.category_name as Category
from products as p
         left join product_categories pc on p.product_id = pc.product_id
         left join categories c on pc.category_id = c.category_id;
