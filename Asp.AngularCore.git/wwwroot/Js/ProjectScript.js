console.log("Hello Khan");
var formdata = document.getElementById("theForm");
formdata.hidden = true;


var shopbtn = document.getElementById("buybtn");
shopbtn.addEventListener("click", function () {
    alert("You Buyed the Product Successfully");
    //  console.log("You Buyed the Product Successfully");

});


var product_Info = document.getElementsByClassName("product-info");
var listItem = product_Info.item[0].children;
