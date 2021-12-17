// Feature: Applying a discount
// Scenario: Eligible Registered Customers get 10% discount when they spend £100 or more

// Given the following Registered Customers
// |Customer Id|Is Eligible|
// |John       |true       |
// |Mary       |true       |
// |Richard    |false      |

// When <Customer Id> spends <Spend>
// Then their order total will be <Total>

// Examples:
// |Customer Id|   Spend|   Total|
// |Mary       |   99.00|   99.00|
// |John       |  100.00|   90.00|
// |Richard    |  100.00|  100.00|
// |Sarah      |  100.00|  100.00|

type Customer =
    | EligibleRegistered of Id: string
    | Registered of Id: string
    | Guest of Id: string

let calculateTotal customer spend =
    let discount =
        match customer with
        | EligibleRegistered customer when spend >= 100M -> spend * 0.1M
        | _ -> 0.0M

    spend - discount


let john = EligibleRegistered "John"

let mary = EligibleRegistered "Mary"

let richard = Registered "Richard"

let sarah = Guest "Sarah"


let assertJohn = calculateTotal john 100.0M = 90.0M
let assertMary = calculateTotal mary 99.0M = 99.0M
let assertRichard = calculateTotal richard 100.0M = 100.0M
let assertSarah = calculateTotal sarah 100.0M = 100.0M
