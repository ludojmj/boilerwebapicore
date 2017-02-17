function callGet(obj) {
    var results = document.getElementById("results");
    obj.addEventListener("click", function (e) {
    var bustCache = "&" + new Date().getTime(),
        oReq = new XMLHttpRequest();
    oReq.onreadystatechange = function () {
        if (oReq.readyState !== 4) {
            results.innerHTML = "Loading ...";
            return;
        }
        if (oReq.status !== 200) {
            results.innerHTML = "Error : " + oReq.responseText;
            return;
        }
        results.innerHTML = "Result : " + oReq.responseText;
    };
    oReq.open("GET", e.target.dataset.url + bustCache, true);
    oReq.setRequestHeader("X-Requested-With", "XMLHttpRequest");
    oReq.setRequestHeader("x-vanillaAjaxWithoutjQuery-version", "1.0");
    oReq.send();
    });
}

function callPost(obj, hasBug) {
    var results = document.getElementById("results");
    obj.addEventListener("click", function (e) {
        var oReq = new XMLHttpRequest();
        oReq.onreadystatechange = function () {
            if (oReq.readyState !== 4) {
                results.innerHTML = "Loading ...";
                return;
            }
            if (oReq.status !== 200) {
                results.innerHTML = "Error : " + oReq.responseText;
                return;
            }
            results.innerHTML = "Result : " + oReq.responseText;
        };
        oReq.open("POST", e.target.dataset.url, true);
        oReq.setRequestHeader("Content-Type", "application/json; charset=UTF-8");
        oReq.setRequestHeader("X-Requested-With", "XMLHttpRequest");
        oReq.setRequestHeader("x-vanillaAjaxWithoutjQuery-version", "1.0");
        oReq.send(hasBug ? "{'Id': '1'}" : "{'Id': '0'}");
    });
}

(function () {
    // GET
    var productKo = document.getElementById("productKo");
    var productOk = document.getElementById("productOk");
    var productAsyncKo = document.getElementById("productAsyncKo");
    var productAsyncOk = document.getElementById("productAsyncOk");

    callGet(productKo);
    callGet(productOk);
    callGet(productAsyncKo);
    callGet(productAsyncOk);

    // POST
    var otherProductKo = document.getElementById("otherProductKo");
    var otherProductOk = document.getElementById("otherProductOk");
    var otherProductAsyncKo = document.getElementById("otherProductAsyncKo");
    var otherProductAsyncOk = document.getElementById("otherProductAsyncOk");

    callPost(otherProductKo, true);
    callPost(otherProductOk, false);
    callPost(otherProductAsyncKo, true);
    callPost(otherProductAsyncOk, false);
}());
