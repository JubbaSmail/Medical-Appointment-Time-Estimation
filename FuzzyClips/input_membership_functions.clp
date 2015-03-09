(deftemplate factor_height
	50 250 Meters
	(
		(Short (Z 50 120))
		(Medium (PI 40 150))
		(tall (S 180 250))
	)
)

(deftemplate factor_Education
	1 6 Degree
	(
		(primary (1 0) (2 1) (3 0))
		(secondry (2 0) (3 1) (4 0))
		(Backaloriuos (3 0) (4 1) (5 0))
		(Master (4 0) (5 1) (6 0))
	)
)

(deftemplate factor_Age
	1 100 Years
	(
		(small (1 0) (5 1) (10 0))
		(Young (7 0) (14 1) (17 0))
		(Adult (16 0) (25 1) (30 0))
		(big (27 0) (40 1) (60 0))
		(elder (50 0) (70 1) (100 0))
	)
)

(deftemplate factor_Place_of_live
	3 200 Km
	(
		(same_City (3 0) (8 1) (10 0))
		(Country_SIde (8 0) (20 1) (30 0))
		(Far (28 0) (100 1) (200 0))
	)
)

(deftemplate factor_Weight
	10 150 kg
	(
		(light (10 0) (20 1) (30 0))
		(medium (25 0) (40 1) (70 0))
	)
)

(deftemplate case
	(slot ID)
	(slot Name)
	(slot height (type FUZZY-VALUE factor_height))
	(slot Education (type FUZZY-VALUE factor_Education))
	(slot Age (type FUZZY-VALUE factor_Age))
	(slot Place_of_live (type FUZZY-VALUE factor_Place_of_live))
	(slot Weight (type FUZZY-VALUE factor_Weight))
)