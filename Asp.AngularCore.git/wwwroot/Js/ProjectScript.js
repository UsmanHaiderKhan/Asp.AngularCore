/// <reference path="../mdb-free/js/jquery-3.3.1.min.js" />
$(document).ready(function () {


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


    var productInfo = $(".product-info li");
    productInfo.on("click",
        function () {
            // console.log("You Clicked On Me...!" + this.innerText);
            console.log("Your Buying Items:" + $(this).text());
        });
    var $loginToggle = $("#Toggling");
    var $loginForm = $("#loginForm");
    $loginToggle.on("click",
        function () {
            $loginForm.slideToggle(1000);
        });
});
