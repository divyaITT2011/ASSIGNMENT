const prompt = require('prompt-sync')({ sigint: true });
console.log("Kindly enter the number of operation's to be performed");
const op = prompt('Enter a number: ');
var cart = [];
for (var i = 0; i < op; i++) {
    const num = prompt('Enter 1 to add product, Enter 2 to update product, Enter 3 to list all the product, Enter 4 to delete product');
    if (num == 1) {
        console.log("Add product to cart");

        var productname = prompt('Enter a productname: ');
        var brand = prompt('Enter a brand: ');
        var price = prompt('Enter a price: ');
        var quantity = prompt('Enter a quantity: ');

        var obj = { NameOfProduct: productname, Price: price, Brand: brand, Quantity: quantity };

        cart.push(obj);
        console.log("Product added successfully in the cart");

    } else if (num == 2) {
        console.log("Update product to cart");
        var productToBeUpdated = prompt('Enter a productToBeUpdated: ');
        var updatedPrice = prompt('Enter a updatedPrice: ');

        for (var i in cart) {
            if (cart[i].NameOfProduct === productToBeUpdated) {
                cart[i].price = updatedPrice;
            }
        }

        console.log("Product updated successfully");

    } else if (num == 3) {
        console.log("print all product's in cart");
        for (var i in cart) {
            console.log(cart[i]);
        }
    } else if (num == 4) {
        console.log("delete product from cart");
        var productname = prompt('Enter a productTodeleted: ');
        for (var i in cart) {
            if (cart[i].NameOfProduct === productname) {
                cart.splice(i, 1);
                console.log("Product removed successfully in the cart");
                break;
            }
        }
    } else {
        console.log("Invalid Operation");
    }
}
