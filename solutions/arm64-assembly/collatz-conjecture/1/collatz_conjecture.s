.equ INVALID_NUMBER, -1

.text
.globl steps

// Calculate Collatz Conjecture number of steps to reach 1
// x0 - input / output
// x1 - tmp value for arithmetic operations
// x4 - stores the number at the current step
// x5 - stores the number of steps taken
// x6 - stores the result of number % 2

steps:
        cmp x0, #1               // Compare input with one
        blt invalid_input       // Return -1 if input is invalid

        mov x4, x0       // Store input uint in x4 register
        mov x5, #0       // Initialize to zero the step counter

// Calculate a single step
step:
        cmp x4, #1       // Check if the input is one
        beq done         // Return if it is
        
        and x6, x4, #1   // Calculate number % 2

        cmp x6, #0       // Check if even
        beq even_step    // If it is jump to even step function
        b odd_step       // Else jump to odd step function

// Calculate step for even number
even_step:
        mov x1, #2       // Store 2 into x1
        udiv x4, x4, x1  // Divide number by 2
        add x5, x5, #1   // Increment number of steps
        b step           // Call step function

// Calculate step for odd number
odd_step:
        mov x1, #3       // Store 3 into x1
        mul x4, x4, x1   // Multiply number by 3
        add x4, x4, #1   // Add 1 to number
        add x5, x5, #1   // Increment number of steps
        b step           // Call step function

// Return number of steps
done:
        mov x0, x5       // Copy number of steps taken into output
        ret              //  Return, program exit point

// Return -1 when input is invalid (< 1)
invalid_input:
        mov x0, #INVALID_NUMBER
        ret
        