  INSERT INTO [ISB].[system].[Properties] ([Id], [PropertyTypeId], [Name], [StreetName], [HouseName], [HouseNumber], [PostCode], [Price], [Deleted], [RegistrationDate], [MachineInfo], [Selling])
VALUES
    ('4803D90F-6CA4-4953-97C0-0E2FBBE2CF1F', 1, 'Cozy Cottage', 'Oak Street', 'Maple House', '123', 'ABCD 123', 250000, 0, GETDATE(), 'Machine 1', 1),
    ('903B3455-969E-40D3-AD44-0F4CDFC4614F', 2, 'Modern Apartment', 'Pine Avenue', 'Birch Apartments', '456', 'EFGH 456', 350000, 0, GETDATE(), 'Machine 2', 0),
    ('8AB6AC0A-4C29-482C-9774-2349A1A5D2C2', 3, 'Suburban Villa', 'Elm Lane', 'Cedar Mansion', '789', 'IJKL 789', 500000, 0, GETDATE(), 'Machine 3', 1),
    ('4741F937-CDCA-43CA-8E38-267949748FE7', 4, 'Seaside Retreat', 'Beach Road', 'Ocean View', '101', 'MNOP 101', 400000, 0, GETDATE(), 'Machine 4', 1),
    ('4FB5B7BE-3DCA-4E0C-8F05-30A1A015179E', 5, 'Mountain Cabin', 'Forest Trail', 'Pine Lodge', '202', 'QRST 202', 300000, 0, GETDATE(), 'Machine 5', 0),
    ('460939C3-EB1A-431E-99E9-324735CC3974', 1, 'Rural Farmhouse', 'Meadow Lane', 'Sunset Farm', '303', 'UVWX 303', 600000, 0, GETDATE(), 'Machine 6', 1),
    ('5CBF131B-5DC0-48E8-BA05-3652FAFB33A3', 2, 'City Loft', 'Main Street', 'Metro Lofts', '404', 'YZAB 404', 450000, 0, GETDATE(), 'Machine 7', 0),
    ('57A5F52F-3299-47F2-93AD-3B2F2C6BA6E0', 3, 'Lakefront Cottage', 'Lakeside Drive', 'Sunrise Cottage', '505', 'CDEF 505', 350000, 0, GETDATE(), 'Machine 8', 1),
    ('5941C25E-16A9-4E8E-9F12-454ECF5BAC49', 4, 'Luxury Penthouse', 'Skyline Avenue', 'Highrise Tower', '606', 'GHIJ 606', 800000, 0, GETDATE(), 'Machine 9', 1),
    ('387B7DA8-BE7C-4CDB-9560-4958085BAB85', 5, 'Forest Cabin', 'Wilderness Road', 'Serenity Cabin', '707', 'KLMN 707', 280000, 0, GETDATE(), 'Machine 10', 0),
    ('BD6A53BC-FA94-40A6-B2CA-52318D74E9CA', 1, 'Historic Manor', 'Heritage Lane', 'Victorian Estate', '808', 'OPQR 808', 700000, 0, GETDATE(), 'Machine 11', 1),
    ('21B88637-161E-497A-AEFF-64B03D2296F3', 2, 'Urban Condo', 'Downtown Boulevard', 'Cityscape Condos', '909', 'STUV 909', 320000, 0, GETDATE(), 'Machine 12', 0),
    ('0224F289-3645-4CF4-9E97-6B26B7D3E349', 3, 'Coastal Bungalow', 'Seashore Road', 'Beachside Bungalow', '1010', 'WXYZ 1010', 380000, 0, GETDATE(), 'Machine 13', 1),
    ('8D3655A4-A8C7-4D87-8C60-6F709E4E0890', 4, 'Ski Chalet', 'Mountain View', 'Snowy Peak Chalet', '1111', 'BCDE 1111', 550000, 0, GETDATE(), 'Machine 14', 1),
    ('3D0230CC-319E-43AA-8A2B-6F84BFC61187', 5, 'Country Retreat', 'Tranquility Lane', 'Peaceful Hideaway', '1212', 'FGHI 1212', 420000, 0, GETDATE(), 'Machine 15', 0),
    ('A89277F7-5627-4305-88B8-6F8C6A8BCD50', 1, 'Waterfront Mansion', 'Bayview Drive', 'Harbor House', '1313', 'JKLM 1313', 900000, 0, GETDATE(), 'Machine 16', 1),
    ('F1B4A540-6949-4896-8849-74D1C3F52FDC', 2, 'Loft Apartment', 'Artists Avenue', 'Gallery Lofts', '1414', 'MNOP 1414', 300000, 0, GETDATE(), 'Machine 17', 0),
    ('28D486C3-3958-425B-BC69-7508CF88FE77', 3, 'Countryside Cottage', 'Rural Route', 'Meadow Cottage', '1515', 'QRST 1515', 370000, 0, GETDATE(), 'Machine 18', 1),
    ('FDB8C3D9-2CC7-4EFA-A113-7A29685026A5', 4, 'Urban Townhouse', 'Metropolis Street', 'City Center Townhomes', '1616', 'UVWX 1616', 480000, 0, GETDATE(), 'Machine 19', 1),
	('88715A92-6129-4E97-A46E-80D0CF033424', 5, 'Riverfront Retreat', 'Riverside Avenue', 'Tranquil Waters', '1717', 'YZAB 1717', 440000, 0, GETDATE(), 'Machine 20', 0),
    ('D2C5C50F-D494-458D-9B62-8330018E0A9D', 1, 'Historic Brownstone', 'Heritage Street', 'Antique Row', '1818', 'CDEF 1818', 620000, 0, GETDATE(), 'Machine 21', 1),
    ('EFAF3605-B054-4F9A-ADCD-8CE9A60F2D60', 3, 'Seaside Cottage', 'Beachfront Road', 'Oceanfront Cottage', '3030', 'YZAB 3030', 400000, 0, GETDATE(), 'Machine 33', 1),
    ('E0C33786-46A4-475B-BF0B-8F553437F051', 4, 'Ski Lodge', 'Slopeside Trail', 'Snowy Slopes Lodge', '3131', 'CDEF 3131', 590000, 0, GETDATE(), 'Machine 34', 1),
    ('18B51E28-C9B4-4C14-B8CA-A27C16E3F149', 5, 'Countryside Chalet', 'Country Road', 'Hillside Chalet', '3232', 'GHIJ 3232', 310000, 0, GETDATE(), 'Machine 35', 0),
    ('9F79B2B4-D21F-457F-991F-A316475A7E21', 1, 'Waterfront Estate', 'Bayshore Drive', 'Harborfront Estate', '3333', 'KLMN 3333', 950000, 0, GETDATE(), 'Machine 36', 1),
    ('E1EF83BF-D704-4ECB-9BA4-A4F8AB4189DA', 2, 'Modern Loft', 'Downtown Drive', 'Urban Loft', '3434', 'OPQR 3434', 370000, 0, GETDATE(), 'Machine 37', 0),
    ('11E5B893-8E1C-4E70-BDD4-A648863491D0', 3, 'Lakefront Retreat', 'Lakeview Drive', 'Sunrise Retreat', '3535', 'STUV 3535', 380000, 0, GETDATE(), 'Machine 38', 1),
    ('05B0548B-30F8-41C5-854B-AB14ED10BD9F', 4, 'Urban Apartment', 'City Center Boulevard', 'Metro Apartments', '3636', 'WXYZ 3636', 490000, 0, GETDATE(), 'Machine 39', 1),
    ('0E84B2AC-ABED-44E0-B056-B02B0B8025AF', 5, 'Mountain View Lodge', 'Scenic Highway', 'Peakview Lodge', '3737', 'BCDE 3737', 600000, 0, GETDATE(), 'Machine 40', 0),
    ('CAD925B2-C2A9-4B8B-BAE7-B94AE09BAB21', 2, 'Highrise Condo', 'Skyline Boulevard', 'Skyview Towers', '1919', 'GHIJ 1919', 330000, 0, GETDATE(), 'Machine 22', 0),
    ('59EC203A-5DF5-4DD0-B530-BE047D64DD58', 3, 'Beachfront Villa', 'Seaside Drive', 'Ocean Breeze Villa', '2020', 'KLMN 2020', 390000, 0, GETDATE(), 'Machine 23', 1),
    ('5B9DADF9-7B0E-4960-B35B-BEAA6F53BB8C', 4, 'Mountain Retreat', 'Summit Trail', 'Alpine Lodge', '2121', 'OPQR 2121', 570000, 0, GETDATE(), 'Machine 24', 1),
    ('895A3898-F4A5-4842-9A7D-BECAE932ED60', 5, 'Lakeview Cabin', 'Lakeshore Avenue', 'Sunset Cabin', '2222', 'STUV 2222', 290000, 0, GETDATE(), 'Machine 25', 0),
    ('A96F6CF1-71F3-4C10-9FAC-C00FC7C71BEB', 1, 'Victorian Mansion', 'Victory Lane', 'Grand Manor', '2323', 'WXYZ 2323', 800000, 0, GETDATE(), 'Machine 26', 1),
    ('FF076533-420D-408C-A896-C1B816148929', 2, 'City Skyline Loft', 'Metropolitan Drive', 'Skyline Lofts', '2424', 'BCDE 2424', 340000, 0, GETDATE(), 'Machine 27', 0),
    ('A8406320-D13F-4822-B734-C9DF05D8BB40', 3, 'Cozy Cabin', 'Forest Road', 'Woodland Retreat', '2525', 'FGHI 2525', 360000, 0, GETDATE(), 'Machine 28', 1),
    ('66CA3E41-11CD-4136-BCFD-E4012385DBE0', 4, 'Luxury Condo', 'Boulevard Avenue', 'Luxury Towers', '2626', 'JKLM 2626', 520000, 0, GETDATE(), 'Machine 29', 1),
    ('A367D026-3507-4B75-B0EB-E7C9F9D42221', 5, 'Riverside Cottage', 'Waterfront Lane', 'Riverbank Cottage', '2727', 'MNOP 2727', 410000, 0, GETDATE(), 'Machine 30', 0),
    ('C2174DE3-8927-4672-957D-F552DE483C25', 1, 'Historic Townhouse', 'Heritage Court', 'Colonial Townhomes', '2828', 'QRST 2828', 650000, 0, GETDATE(), 'Machine 31', 1),
    ('D47CD8BC-AECE-499F-B508-F8D71BB8815E', 2, 'Urban Penthouse', 'Cityscape Avenue', 'Metropolis Penthouse', '2929', 'UVWX 2929', 350000, 0, GETDATE(), 'Machine 32', 0);


INSERT INTO [ISB].[system].[Contacts] ([Id], [FirstName], [LastName], [PhoneNumber], [Email], [Deleted], [CreatedDate], [MachineInfo])
VALUES
    ('C2711E83-3637-4F5B-AF65-0BC04FEA8765', 'John', 'Doe', '1234567890', 'john@example.com', 0, GETDATE(), 'Machine Info 1'),
    ('2924CE25-BF48-4663-A57C-13D159314FCA', 'Jane', 'Doe', '0987654321', 'jane@example.com', 0, GETDATE(), 'Machine Info 2'),
    ('97868782-1214-416E-A56B-42894F389DEF', 'Alice', 'Smith', '5551234567', 'alice@example.com', 0, GETDATE(), 'Machine Info 3'),
    ('351CBDC3-B8CD-4414-A2AA-4BA6417FB880', 'Bob', 'Johnson', '9998887776', 'bob@example.com', 0, GETDATE(), 'Machine Info 4'),
    ('7B9B49CF-81D2-4A43-8101-6750DAE774D9', 'Emily', 'Brown', '1112223334', 'emily@example.com', 0, GETDATE(), 'Machine Info 5'),
    ('0F5E71AD-5809-4101-9156-B5D99284B03F', 'Michael', 'Wilson', '4445556667', 'michael@example.com', 0, GETDATE(), 'Machine Info 6'),
    ('27EC872C-4744-48FD-950A-C0C940D16EC3', 'Emma', 'Taylor', '7778889990', 'emma@example.com', 0, GETDATE(), 'Machine Info 7'),
    ('C3AB2055-5B61-4974-8D05-CF27145F2474', 'William', 'Jones', '3334445556', 'william@example.com', 0, GETDATE(), 'Machine Info 8'),
    ('F1E20B3B-3BE7-42AB-9484-F3274A64D2F0', 'Olivia', 'Martinez', '6667778889', 'olivia@example.com', 0, GETDATE(), 'Machine Info 9'),
    ('D1A292FA-F368-4F8F-9198-FB4EBB8068A7', 'James', 'Davis', '2223334445', 'james@example.com', 0, GETDATE(), 'Machine Info 10');


INSERT INTO [ISB].[system].[PropertyOwnerships] ([Id], [ContactId], [PropertyId], [AskingPrice], [PriceAcquisition], [Deleted], [EffectiveFrom], [EffectiveTill], [MachineInfo])
VALUES
    (NEWID(), 'C2711E83-3637-4F5B-AF65-0BC04FEA8765', 'BD6A53BC-FA94-40A6-B2CA-52318D74E9CA', 100000, 95000, 0, GETDATE(), NULL, 'Machine Info 1'),
    (NEWID(), '2924CE25-BF48-4663-A57C-13D159314FCA', 'E0C33786-46A4-475B-BF0B-8F553437F051', 150000, 140000, 0, GETDATE(), NULL, 'Machine Info 2'),
    (NEWID(), 'C2711E83-3637-4F5B-AF65-0BC04FEA8765', 'C2174DE3-8927-4672-957D-F552DE483C25', 200000, 180000, 0, GETDATE(), NULL, 'Machine Info 3'),
    (NEWID(), '97868782-1214-416E-A56B-42894F389DEF', '59EC203A-5DF5-4DD0-B530-BE047D64DD58', 180000, 170000, 0, GETDATE(), NULL, 'Machine Info 4'),
    (NEWID(), 'D1A292FA-F368-4F8F-9198-FB4EBB8068A7', '4FB5B7BE-3DCA-4E0C-8F05-30A1A015179E', 220000, 210000, 0, GETDATE(), NULL, 'Machine Info 5'),
    (NEWID(), 'F1E20B3B-3BE7-42AB-9484-F3274A64D2F0', 'BD6A53BC-FA94-40A6-B2CA-52318D74E9CA', 250000, 240000, 0, GETDATE(), NULL, 'Machine Info 6'),
    (NEWID(), '0F5E71AD-5809-4101-9156-B5D99284B03F', 'EFAF3605-B054-4F9A-ADCD-8CE9A60F2D60', 300000, 280000, 0, GETDATE(), NULL, 'Machine Info 7'),
    (NEWID(), 'F1E20B3B-3BE7-42AB-9484-F3274A64D2F0', '903B3455-969E-40D3-AD44-0F4CDFC4614F', 280000, 260000, 0, GETDATE(), NULL, 'Machine Info 8'),
    (NEWID(), '0F5E71AD-5809-4101-9156-B5D99284B03F', '05B0548B-30F8-41C5-854B-AB14ED10BD9F', 350000, 320000, 0, GETDATE(), NULL, 'Machine Info 9'),
    (NEWID(), '0F5E71AD-5809-4101-9156-B5D99284B03F', '3D0230CC-319E-43AA-8A2B-6F84BFC61187', 400000, 380000, 0, GETDATE(), NULL, 'Machine Info 10');















