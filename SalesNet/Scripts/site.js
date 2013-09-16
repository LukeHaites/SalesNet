$(document).ready(function () {
  $("body").on("click", ".showdets", function () {
    $(this).closest("tr").next("tr").find("div").slideDown(200);
  });

  $("body").on("click", ".hidedets", function () {
    $(this).closest("tr").find("div").slideUp(200);
  });
});