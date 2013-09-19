$(document).ready(function () {
  $("body").on("click", ".showdets", function () {
    $(this).closest("tr").next("tr").find("div").slideToggle(200);
  });
});