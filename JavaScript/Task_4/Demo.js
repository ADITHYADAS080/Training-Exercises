let products = [];

class Product {
  constructor(Pname, price, quantity) {
    this.name = Pname;
    this.price = price;
    this.quantity = quantity;
  }
}

let Productname = document.querySelector(".productname");
let productPrice = document.querySelector(".price");
let quantity = document.querySelector(".qty");
let table = document.querySelector(".pTable");
let editBtn = document.querySelector(".editBtn");

function displayProducts() {
  table.innerHTML = "";
  products.forEach((product, index) => {
    let row = document.createElement("tr");
    let td_name = document.createElement("td");
    let td_price = document.createElement("td");
    let td_qty = document.createElement("td");
    let td_Action = document.createElement("td");

    let deleteBtn = document.createElement("button");
    deleteBtn.textContent = "Delete";
    deleteBtn.classList = "action delete";
    deleteBtn.onclick = () => deleteProduct(index);

    let editButton = document.createElement("button");
    editButton.textContent = "Edit";
    editButton.classList = "action edit";
    editButton.onclick = () => editProduct(index);

    td_Action.appendChild(deleteBtn);
    td_Action.appendChild(editButton);

    td_name.textContent = product.name;
    td_price.textContent = product.price;
    td_qty.textContent = product.quantity;

    row.appendChild(td_name);
    row.appendChild(td_price);
    row.appendChild(td_qty);
    row.appendChild(td_Action);
    table.appendChild(row);
  });
}

function addProduct() {
  if (
    Productname.value === "" ||
    productPrice.value === "" ||
    quantity.value === ""
  ) {
    alert("Please fill in all fields before adding a product.");
    return;
  }

  products.push(
    new Product(Productname.value, productPrice.value, quantity.value)
  );

  Productname.value = "";
  productPrice.value = "";
  quantity.value = "";

  displayProducts();
}

function deleteProduct(index) {
  products.splice(index, 1);
  displayProducts();
}

function editProduct(index) {
  let newProductname = document.querySelector(".Editproductname");
  let newproductPrice = document.querySelector(".Editprice");
  let newquantity = document.querySelector(".Editqty");
  let editform = document.querySelector(".editform");

  editform.style.display = "block";
  newProductname.value = products[index].name;
  newproductPrice.value = products[index].price;
  newquantity.value = products[index].quantity;
  document.querySelector(".index").value = index;
}

editBtn.addEventListener("click", () => {
  let newProductname = document.querySelector(".Editproductname");
  let newproductPrice = document.querySelector(".Editprice");
  let newquantity = document.querySelector(".Editqty");
  let index = Number(document.querySelector(".index").value);

  products[index].name = newProductname.value;
  products[index].price = newproductPrice.value;
  products[index].quantity = newquantity.value;

  document.querySelector(".editform").style.display = "none";
  displayProducts();
});