INSERT INTO public."Type"(
	type_id, type_name)
	VALUES (1, '{GeForce}');
INSERT INTO public."Type"(
	type_id, type_name)
	VALUES (2, '{AMD}');

INSERT INTO public."Manufacturer"(
	manufacturer_id, manufacturer_name, type_id)
	VALUES (1, '{Palit}', 1);
INSERT INTO public."Manufacturer"(
	manufacturer_id, manufacturer_name, type_id)
	VALUES (2, '{Gigabyte}', 1);
INSERT INTO public."Manufacturer"(
	manufacturer_id, manufacturer_name, type_id)
	VALUES (3, '{MSI}', 1);
INSERT INTO public."Manufacturer"(
	manufacturer_id, manufacturer_name, type_id)
	VALUES (4, '{ASUS}', 1);
INSERT INTO public."Manufacturer"(
	manufacturer_id, manufacturer_name, type_id)
	VALUES (5, '{ASRock}', 2);
INSERT INTO public."Manufacturer"(
	manufacturer_id, manufacturer_name, type_id)
	VALUES (6, '{Sapphire}', 2);

INSERT INTO public."Shop"(
	shop_id, shop_city, shop_name)
	VALUES (1, '{Keln}', '{GPShop_Keln}');
INSERT INTO public."Shop"(
	shop_id, shop_city, shop_name)
	VALUES (2, '{Hamburg}', '{GPShop_Hamburg}');
INSERT INTO public."Shop"(
	shop_id, shop_city, shop_name)
	VALUES (3, '{Frankfurt}', '{GPShop_Frankfurt}');
INSERT INTO public."Shop"(
	shop_id, shop_city, shop_name)
	VALUES (4, '{London}', '{GPShop_London}');
INSERT INTO public."Shop"(
	shop_id, shop_city, shop_name)
	VALUES (5, '{Paris}', '{GPShop_Paris}');

INSERT INTO public."Card"(
	card_id, category_id, type_id, card_gpu_name, gpu, ram, cooler_num, card_price, card_num)
	VALUES (1, 1, 1, '{RTX}', 3050, 6, 1, 24000, 10);
INSERT INTO public."Card"(
	card_id, category_id, type_id, card_gpu_name, gpu, ram, cooler_num, card_price, card_num)
	VALUES (2, 2, 1, '{RTX}', 4070, 12, 3, 70000, 1);
INSERT INTO public."Card"(
	card_id, category_id, type_id, card_gpu_name, gpu, ram, cooler_num, card_price, card_num)
	VALUES (3, 2, 1, '{RTX}', 4090, 24, 3, 250000, 4);
INSERT INTO public."Card"(
	card_id, category_id, type_id, card_gpu_name, gpu, ram, cooler_num, card_price, card_num)
	VALUES (4, 2, 2, '{Radeon_RX}', 7700, 12, 3, 56000, 50);	
INSERT INTO public."Card"(
	card_id, category_id, type_id, card_gpu_name, gpu, ram, cooler_num, card_price, card_num)
	VALUES (5, 2, 1, '{RTX}', 3050, 8, 2, 30000, 15);
INSERT INTO public."Card"(
	card_id, category_id, type_id, card_gpu_name, gpu, ram, cooler_num, card_price, card_num)
	VALUES (6, 3, 1, '{RTX}', 4060, 8, 2, 39000, 10);
INSERT INTO public."Card"(
	card_id, category_id, type_id, card_gpu_name, gpu, ram, cooler_num, card_price, card_num)
	VALUES (7, 3, 1, '{GTX}', 1650, 4, 2, 15000, 40);
INSERT INTO public."Card"(
	card_id, category_id, type_id, card_gpu_name, gpu, ram, cooler_num, card_price, card_num)
	VALUES (8, 3, 1, '{RTX}', 4090, 24, 3, 235000, 3);
	INSERT INTO public."Card"(
	card_id, category_id, type_id, card_gpu_name, gpu, ram, cooler_num, card_price, card_num)
	VALUES (9, 4, 1, '{RTX}', 4080, 16, 2, 130000, 2);
INSERT INTO public."Card"(
	card_id, category_id, type_id, card_gpu_name, gpu, ram, cooler_num, card_price, card_num)
	VALUES (10, 4, 1, '{RTX}', 4070, 12, 3, 66000, 32);
INSERT INTO public."Card"(
	card_id, category_id, type_id, card_gpu_name, gpu, ram, cooler_num, card_price, card_num)
	VALUES (11, 4, 1, '{RTX}', 3050, 8, 2, 27000, 4);
INSERT INTO public."Card"(
	card_id, category_id, type_id, card_gpu_name, gpu, ram, cooler_num, card_price, card_num)
	VALUES (12, 5, 2, '{Radeon_RX}', 6800, 16, 3, 56000, 50);	
INSERT INTO public."Card"(
	card_id, category_id, type_id, card_gpu_name, gpu, ram, cooler_num, card_price, card_num)
	VALUES (13, 5, 2, '{Radeon_RX}', 6700, 12, 2, 42000, 18);
INSERT INTO public."Card"(
	card_id, category_id, type_id, card_gpu_name, gpu, ram, cooler_num, card_price, card_num)
	VALUES (14, 6, 2, '{Radeon_RX}', 6400, 4, 1, 14000, 7);
INSERT INTO public."Card"(
	card_id, category_id, type_id, card_gpu_name, gpu, ram, cooler_num, card_price, card_num)
	VALUES (15, 6, 2, '{Radeon_RX}', 7900, 24, 3, 123000, 3);

INSERT INTO public."Shop_card"(
	card_id, shop_id, card_shop_id)
	VALUES (1, 1, 1);
INSERT INTO public."Shop_card"(
	card_id, shop_id, card_shop_id)
	VALUES (2, 1, 2);
INSERT INTO public."Shop_card"(
	card_id, shop_id, card_shop_id)
	VALUES (3, 1, 3);
INSERT INTO public."Shop_card"(
	card_id, shop_id, card_shop_id)
	VALUES (4, 2, 4);
INSERT INTO public."Shop_card"(
	card_id, shop_id, card_shop_id)
	VALUES (5, 2, 5);
INSERT INTO public."Shop_card"(
	card_id, shop_id, card_shop_id)
	VALUES (6, 2, 6);
INSERT INTO public."Shop_card"(
	card_id, shop_id, card_shop_id)
	VALUES (7, 3, 7);
INSERT INTO public."Shop_card"(
	card_id, shop_id, card_shop_id)
	VALUES (8, 3, 8);
INSERT INTO public."Shop_card"(
	card_id, shop_id, card_shop_id)
	VALUES (9, 3, 9);
INSERT INTO public."Shop_card"(
	card_id, shop_id, card_shop_id)
	VALUES (10, 4, 10);
INSERT INTO public."Shop_card"(
	card_id, shop_id, card_shop_id)
	VALUES (11, 4, 11);
INSERT INTO public."Shop_card"(
	card_id, shop_id, card_shop_id)
	VALUES (12, 4, 12);
INSERT INTO public."Shop_card"(
	card_id, shop_id, card_shop_id)
	VALUES (13, 5, 13);
INSERT INTO public."Shop_card"(
	card_id, shop_id, card_shop_id)
	VALUES (14, 5, 14);
INSERT INTO public."Shop_card"(
	card_id, shop_id, card_shop_id)
	VALUES (15, 5, 15);

INSERT INTO public."User"(
	user_id, user_name, user_city, user_adres, user_role, user_login, user_password)
	VALUES (1, '{Yorik}', '{Keln}', '{Sovetskaya_53}', '{customer}', '{Yorik_log}', '{Yorik_pass}');
INSERT INTO public."User"(
	user_id, user_name, user_city, user_adres, user_role, user_login, user_password)
	VALUES (2, '{Hans}', '{Hamburg}', '{Nemetskaya_12}', '{customer}', '{Hans_log}', '{Hans_pass}');
INSERT INTO public."User"(
	user_id, user_name, user_city, user_adres, user_role, user_login, user_password)
	VALUES (3, '{Alexander}', '{Frankfurt}', '{Pivnaya_112a}', '{customer}', '{Alex_log}','{Alex_pass}');
INSERT INTO public."User"(
	user_id, user_name, user_city, user_adres, user_role, user_login, user_password)
	VALUES (4, '{Zelda}', '{Berlin}', '{HotDogStreet_9}', '{customer}', '{Zelda_log}', '{Zelda_pass}');
INSERT INTO public."User"(
	user_id, user_name, user_city, user_adres, user_role, user_login, user_password)
	VALUES (5, '{Oxxxymiron}', '{London}', '{OpticRussia_16}', '{customer}', '{Oxy_log}', '{Oxy_pass}');
INSERT INTO public."User"(
	user_id, user_name, user_city, user_adres, user_role, user_login, user_password)
	VALUES (6, '{Ad}', '{-}', '{-}', '{admin}', '{root}', '{root}');
INSERT INTO public."User"(
	user_id, user_name, user_city, user_adres, user_role, user_login, user_password)
	VALUES (7, '{Keln_moder}', '{Keln}', '{Babusova_12}', '{moder}', '{KM_log}', '{KM_rass}');

	
	
INSERT INTO public."Shipment"(
	shipment_id, user_id, shipment_date)
	VALUES (1, 1, '2024-03-20');
INSERT INTO public."Shipment"(
	shipment_id, user_id, shipment_date)
	VALUES (2, 2, '2024-04-08');
INSERT INTO public."Shipment"(
	shipment_id, user_id, shipment_date)
	VALUES (3, 3, '2024-04-20');
INSERT INTO public."Shipment"(
	shipment_id, user_id, shipment_date)
	VALUES (4, 4, '2024-05-10');
INSERT INTO public."Shipment"(
	shipment_id, user_id, shipment_date)
	VALUES (5, 5, '2024-05-10');
	

INSERT INTO public."Order"(
	order_id, shipment_id, order_date)
	VALUES (1, 1, '2024-03-12');
INSERT INTO public."Order"(
	order_id, shipment_id, order_date)
	VALUES (2, 2, '2024-04-01');
INSERT INTO public."Order"(
	order_id, shipment_id, order_date)
	VALUES (3, 3, '2024-04-10');
INSERT INTO public."Order"(
	order_id, shipment_id, order_date)
	VALUES (4, 4, '2024-05-02');
INSERT INTO public."Order"(
	order_id, shipment_id, order_date)
	VALUES (5, 5, '2024-05-01');

INSERT INTO public."Card_order"(
	card_id, order_id, card_order_id)
	VALUES (1, 1, 1);
INSERT INTO public."Card_order"(
	card_id, order_id, card_order_id)
	VALUES (7, 1, 2);
INSERT INTO public."Card_order"(
	card_id, order_id, card_order_id)
	VALUES (4, 2, 3);
INSERT INTO public."Card_order"(
	card_id, order_id, card_order_id)
	VALUES (8, 3, 4);
INSERT INTO public."Card_order"(
	card_id, order_id, card_order_id)
	VALUES (13, 4, 5);
INSERT INTO public."Card_order"(
	card_id, order_id, card_order_id)
	VALUES (15, 5, 6);
	
