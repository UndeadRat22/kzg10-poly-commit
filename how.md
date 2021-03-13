### Steps

#### 1. Build a polynomial of degree n

How, What data is needed?
A polynomial can be described as an array of numbers, where the i'th number corresponds to the multiplier of the i'th degree
i.e: [5, 10, 15, 66] => 5 + 10x + 15xx + 66xxx

#### Field Elements

Field elements should be represented by some structure like:

```
{
    Order: 17 -- must be prime
    Value: 5 -- [0 .. 16]
}
```

        //https://github.com/protolambda/go-kzg/blob/7b02600fc0c856bd8e30a9d72ce3a3e9a03f38db/setup.go
        //čia x, (x^n) reiktų turėt ant G1 ir čia bus žinomas taškas
