console.log("Hello Khan");
//var formdata = document.getElementById("theForm");
//formdata.hidden = true;

var theForm = $("#theForm");
theForm.hide();


//var shopbtn = document.getElementById("buybtn");
//shopbtn.addEventListener("click", function () {
//    alert("You Buyed the Product Successfully");
//    console.log("You Buyed the Product Successfully");

//});


var shopBtn = $("#buybtn");
shopBtn.on("click",
    function () {
        console.log("You Buyed the Product Successfully");
    });



//var product_Info = document.getElementsByClassName("product-info");
//var listItem = product_Info.item[0].children;


var product_Info = $(".product-info li");
product_Info.on("click",
    function () {
        // console.log("You Clicked On Me...!" + this.innerText);
        console.log("You Clicked On Me...!" + $(this).text());
    });
