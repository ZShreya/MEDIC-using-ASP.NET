select * from Configs

insert into Configs ([Key], [Value]) values ('FacebookURL', 'https://www.facebook.com/farhannn69/')

insert into Configs ([Key], [Value]) values ('CompanyAddress', 'Iqbal Road, Mohammadpur, Dhaka')

insert into Configs ([Key], [Value]) values ('CompanyPhone', '+880 1716 08758')

insert into Configs ([Key], [Value]) values ('FacebookURL', 'ab151farhan@gmail.com')

update Configs set [Value] = 'Mohammadpur, Dhaka' where [Key] = 'CompanyAddress'