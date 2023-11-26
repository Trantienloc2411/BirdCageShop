(function ($) {
    "use strict";
    
    function formatMoney(amount) {
        var numericAmount = parseFloat(amount);
        var roundedAmount = Math.round(numericAmount * 100) / 100;
        return roundedAmount.toLocaleString('vi-VN');
    }
    function convertHoursToDaysAndHours(hours) {
        var days = Math.floor(hours / 24);
        var remainingHours = Math.floor(hours % 24);
        return days + " ngày " + remainingHours + " giờ";
    }
    
    
    // kiểu lồng
    var cage_style = [
        {id: 1, material: "Lồng tròn", time: 48, base_money: 400000, wage: 100000},
        {id: 2, material: "Lồng vuông", time: 36, base_money: 300000, wage: 50000},
    ];
    // Nắp lồng
    var cage_lid = [
        {id: 1, material: "Nhựa", time: 12, base_money: 200000, wage: 80000},
        {id: 2, material: "Gỗ", time: 24, base_money: 400000, wage: 150000},
        {id: 3, material: "Nhôm", time: 8, base_money: 300000, wage: 100000},
    ];
    // Nan lồng
    var cage_body = [
        {id: 1, material: "Nhựa", time: 1/60, base_money: 10000, wage: 5000},
        {id: 2, material: "Gỗ", time: 1/6, base_money: 30000, wage: 15000},
        {id: 3, material: "Nhôm", time: 1/30, base_money: 25000, wage: 10000},
    ];
    // cửa lồng
    var cage_window = [
        {id: 1, material: "Nhựa", size: "M", time: 3, base_money: 40000, wage: 10000},
        {id: 2, material: "Nhựa", size: "L", time: 5, base_money: 60000, wage: 20000},
        {id: 3, material: "Nhựa", size: "XL", time: 7, base_money: 80000, wage: 20000},
        {id: 4, material: "Nhôm", size: "M", time: 4, base_money: 80000, wage: 20000},
        {id: 5, material: "Nhôm", size: "L", time: 7, base_money: 120000, wage: 30000},
        {id: 6, material: "Nhôm", size: "XL", time: 10, base_money: 140000, wage: 30000},
    ];
    var cage_window_material = "Nhựa";
    var case_window_size = "M";
    // đế lồng
    var cage_base = [
        {id: 1, material: "Nhựa", time: 3, base_money: 50000, wage: 30000},
        {id: 2, material: "Gỗ", time: 7, base_money: 200000, wage: 80000},
        {id: 3, material: "Nhôm", time: 5, base_money: 100000, wage: 40000},
    ];
    // Dữ liệu người dùng đã chọn.
    var formData = {
        cage_body_input: 0,
        cage_style: {id: 1, material: "Lồng tròn", time: 48, base_money: 400000, wage: 100000},
        cage_lid: {id: 1, material: "Nhựa", time: 12, base_money: 200000, wage: 80000},
        cage_body: {id: 1, material: "Nhựa", time: 1/60, base_money: 10000, wage: 5000},
        cage_base: {id: 1, material: "Nhựa", time: 3, base_money: 50000, wage: 30000},
        cage_window: {id: 1, material: "Nhựa", size: "M", time: 3, base_money: 40000, wage: 10000}
    }
    var totalTime = 0;
    var totalBaseMoney = 0;
    var totalWage = 0;
    var totalMoney = 0;
    
    function calculateBill() {
        totalTime = formData.cage_style.time + formData.cage_lid.time + formData.cage_body.time * formData.cage_body_input + formData.cage_base.time + formData.cage_window.time;
        
        // Chuyển đổi giờ thành ngày + giờ
        var totalTimeFormatted = convertHoursToDaysAndHours(totalTime);
    
        totalBaseMoney = formData.cage_style.base_money + formData.cage_lid.base_money + formData.cage_body.base_money * formData.cage_body_input + formData.cage_base.base_money + formData.cage_window.base_money;
        totalWage = formData.cage_style.wage + formData.cage_lid.wage + formData.cage_body.wage * formData.cage_body_input + formData.cage_base.wage + formData.cage_window.wage;
        totalMoney = totalBaseMoney + totalWage;
    
        $("#totalTime").text(totalTimeFormatted);
        $("#totalBaseMoney").text(formatMoney(totalBaseMoney) + " vnđ");
        $("#totalWage").text(formatMoney(totalWage) + " vnđ");
        $("#totalMoney").text(formatMoney(totalMoney) + " vnđ");

        var imageSrc = ''; // Set the default image source
        if (selectedValue === '1029') {
            // Change image source for option 1 (Tròn)
            imageSrc = '/img/cat-1.jpg';
        } else if (selectedValue === '1030') {
            // Change image source for option 2 (Vuông)
            imageSrc = '/img/cat-2.jpg';
        }
        // Update the image source
        $('.bo-1 img').attr('src', imageSrc);
    }
    // Dropdown on mouse hover
    $(document).ready(function () {
        calculateBill();

        function toggleNavbarMethod() {
            if ($(window).width() > 992) {
                $('.navbar .dropdown').on('mouseover', function () {
                    $('.dropdown-toggle', this).trigger('click');
                }).on('mouseout', function () {
                    $('.dropdown-toggle', this).trigger('click').blur();
                });
            } else {
                $('.navbar .dropdown').off('mouseover').off('mouseout');
            }
        }
        toggleNavbarMethod();
        $(window).resize(toggleNavbarMethod);
    });
    
    
    // Back to top button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('.back-to-top').fadeIn('slow');
        } else {
            $('.back-to-top').fadeOut('slow');
        }
    });
    $('.back-to-top').click(function () {
        $('html, body').animate({scrollTop: 0}, 1500, 'easeInOutExpo');
        return false;
    });


    // Vendor carousel
    $('.vendor-carousel').owlCarousel({
        loop: true,
        margin: 29,
        nav: false,
        autoplay: true,
        smartSpeed: 1000,
        responsive: {
            0:{
                items:2
            },
            576:{
                items:3
            },
            768:{
                items:4
            },
            992:{
                items:5
            },
            1200:{
                items:6
            }
        }
    });


    // Related carousel
    $('.related-carousel').owlCarousel({
        loop: true,
        margin: 29,
        nav: false,
        autoplay: true,
        smartSpeed: 1000,
        responsive: {
            0:{
                items:1
            },
            576:{
                items:2
            },
            768:{
                items:3
            },
            992:{
                items:4
            }
        }
    });


    // Product Quantity
    $('.quantity button').on('click', function () {
        var button = $(this);
        var oldValue = button.parent().parent().find('input').val();
        if (button.hasClass('btn-plus')) {
            var newVal = parseFloat(oldValue) + 1;
        } else {
            if (oldValue > 0) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 0;
            }
        }
        button.parent().parent().find('input').val(newVal);
    });

    $(".cage-style").on("change", function () {
        var selectedValue = $(this).val();
        var selectedCage = cage_style.find(x => x.id == selectedValue);
        formData.cage_style = selectedCage;
        calculateBill();
    });

    $(".cage_lid").on("change", function () {
        var selectedValue = $(this).val();
        var selectedCage = cage_lid.find(x => x.id == selectedValue);
        formData.cage_lid = selectedCage;
        calculateBill();
    });

    $(".cage_body").on("change", function () {
        var selectedValue = $(this).val();
        var selectedCage = cage_body.find(x => x.id == selectedValue);
        formData.cage_body = selectedCage;
        calculateBill();
    });

    $(".cage_window_material").on("change", function () {
        var selectedMaterial = $(this).val();
        var selectedSize = formData.cage_window.size;
        var selectedCageWindow = cage_window.find(x => x.material == selectedMaterial && x.size == selectedSize);
        formData.cage_window = selectedCageWindow;
        calculateBill();
    });

    $(".cage_window_size").on("change", function () {
        var selectedSize = $(this).val();
        var selectedMaterial = formData.cage_window.material;
        var selectedCageWindow = cage_window.find(x => x.material == selectedMaterial && x.size == selectedSize);
        formData.cage_window = selectedCageWindow;
        calculateBill();
    });

    $(".cage_base").on("change", function () {
        var selectedValue = $(this).val();
        var selectedCage = cage_base.find(x => x.id == selectedValue);
        formData.cage_base = selectedCage;
        calculateBill();
    });

    $(".cage_body_input").on("input", function () {
        var value = $(this).val();
        formData.cage_body_input = +value;
        calculateBill();
    });
    
})(jQuery);

