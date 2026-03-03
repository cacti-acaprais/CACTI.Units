# CACTI.Units
Manage units with conversions and mathematical operations.

Most code is generated through ISourceGenerator with AdditionalFiles for units descriptions.

## Unit Dimensions
Units are defined by their base dimensions like:
- Distances
- Durations
- Radiation doses
- Temperatures
- Ratios
- Masses

## Composed unit dimensions
Some units dimensions are composed by other dimensions like:
- Speeds (Distance / Duration)
- Accelerations (Speed / Duration)
- Radation rates (Dose / Duration)
- Surface (Distance²)

# Comparisons
Units of the same dimensions can be compared:
- Equality (Equals or ==)
- Difference ( != )  
- Superior ( > )
- Inferior ( < )
- Superior or equal ( >= )
- Inferior or equal ( <= )

~~~C#
Speed speed = (MeterPerSecond)10;
KilometerPerHour kilometerPerHour = 60;
Assert.IsTrue(kilometerPerHour > speed);
Assert.IsTrue(kilometerPerHour >= speed);
Assert.IsTrue(kilometerPerHour != speed);

MeterPerSecond meterPerSecond = 60;
kilometerPerHour = 216;
Assert.IsTrue(meterPerSecond >= kilometerPerHour);
Assert.IsTrue(meterPerSecond == kilometerPerHour);
~~~

# Mathematical operations
All unit dimensions support the bellows operations:
- Division (unit = unit / double)
- Multiplication (unit = unit * double)
- Addition (unit = unit + unit)
- Substraction (unit = unit - unit)

The unit of an operation result is always the left operand unit.

~~~C#
SquareMeter squareMeter = 120;
Surface surface = squareMeter - (SquareMeter)30;
Assert.AreEqual("90 m2", surface.ToString());
~~~

## Ratios operations
Along with mathematical operations bellow ratios operations are supported:
- Ratio (ratio = unit / unit)
- Division (unit = unit / ratio)
- Multiplicaiton (unit = unit * ratio)
- Addition (unit = unit + ratio)
- Subsraction (unit = unit - ratio)

~~~C#
Ratio ratio = (MillisievertPerHour)50 / (MillisievertPerHour)200;
Assert.AreEqual("0.25", ratio.ToString());

MillisievertPerHour millisievertPerHour = (MillisievertPerHour)50 + (Percent)50;
Assert.AreEqual("75 mSv/h", millisievertPerHour.ToString());
~~~

# Serialization
All units can be serialized with formatting:
~~~C#
Meter distance = 50.555;
Assert.AreEqual("50.555 m", distance.ToString());
Assert.AreEqual("50.555 m", string.Format("{0}", distance));
Assert.AreEqual("50.55 m", distance.ToString("F2"));
Assert.AreEqual("50.55 m", string.Format("{0:F2}", distance));
~~~

# Parsing
A text can be parsed with the 

~~~C#
Speed speed = Speed.Parse("5 m/s");
Assert.AreEqual("5 m/s", speed.ToString());

KilometerPerHour kilometerPerHour = KilometerPerHour.Parse("5 m/s");
Assert.AreEqual("18 km/h", kilometerPerHour.ToString());
~~~
