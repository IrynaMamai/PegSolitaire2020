function myFunction(row, column) {
    var elem = row + "." + column;
    console.log(elem);
    document.getElementById(elem).setAttribute("class", "democlass");
}