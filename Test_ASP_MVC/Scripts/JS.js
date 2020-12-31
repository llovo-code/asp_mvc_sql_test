
$(document).ready(load)


function load() {
   // $('#Cod_pedido').val("00000001")
    total()
    $('#addTable').click(add_data_table)
    $('body').on('click', '#delete_row', delete_row)
    $('body').on('click', '#add_quantity', add_quantity)
    $('table').on('click', '#delete_quantity', delete_quantity)

}


function delete_row() {

    $(this).parent().parent().fadeOut('slow', function () {
        total()
        $(this).remove()
        total()
    })

    total()
}


function add_data_table() {


    var art = $("#Articulo").val()
    var q = $("#Cantidad").val()
    var p = $("#Precio").val()
    var op = $('#Cod_pedido').val()

    if (valid()) {

        $("#order_table")
            .append(
                $('<tr>').addClass('row').append(
                    $('<td>').append(
                        $('<button>').attr({
                            'type': 'text',
                            'id': 'delete_row'
                        }).addClass('btn btn-danger').text('Eliminar')
                    )
                ).append(
                    $('<td>').append(
                        op.toString()
                    ).hide()
                ).append(
                    $('<td>').append(
                        art.toString()
                    )
                ).append(
                    $('<td>').append(
                        q.toString()
                    )
                ).append(
                    $('<td>').append(
                        p.toString()
                    )
                ).append(
                    $('<td>').append(
                        (p * q).toFixed(2).toString()
                    )
                ).append(
                    $('<td>').append(
                        $('<button>').attr('type', 'text').addClass(' btn ').text('+').attr('id', 'add_quantity')
                    ).append(
                        $('<button>').attr({
                            'type': 'text',
                            'id': 'delete_quantity'
                        }).addClass('btn').text('-').css('margin-left', '5px')
                    )
                )
        )
       
        $("#Articulo").val('')
        $("#Cantidad").val('')
         $("#Precio").val('')
        total()
    } else {
        alert(`Rellene Todos los Campos`)
    }
 

}

function valid () {
    var inpt = $('#order_section').find('input')
    var empty =0

    for (var i = 0; i < inpt.length; i++) {
        
        if (i != 0   && i != 4 && i != 5) {
           
            var data = inpt.eq(i).val();
        
            if (data.length  < 1) {
                empty++;
            }
        }
    }

    if (empty == 0) {
      
        return true
    } else {
     
        return false
    }

    


}


function total() {
    var rows = $('#order_table tbody ')
    var coln = $('#order_table tr:last td').length
    var data = ''
    var sum = 0

   // alert(rows.children('tr').length)
    for (var i = 0; i < rows.children('tr').length;i++) {
     //   sum = sum + parseInt($('#order_table').children('tbody').children('tr')[i].children('td')[4].val())
        data = parseFloat($('#order_table tbody tr').eq(i).find('td').eq(5).html())
        sum += data
       // alert(sum)
    }

    
    
    $('#subtotal').val(sum)
    $('#iva').val(parseFloat(sum * 0.15).toFixed(4))
    $('#Total_Pedido').val(parseFloat(sum + (sum * 0.15)))

   
}


function add_quantity() {
    
    var suma = parseInt($(this).parent().parent().find('td').eq(3).html())
    var price = parseFloat($(this).parent().parent().find('td').eq(4).html())
    

    $(this).parent().parent().find('td').eq(3).html(++suma)
    $(this).parent().parent().find('td').eq(5).html(suma * price)

    total()
   
}


function delete_quantity() {

    var del = parseInt($(this).parent().parent().find('td').eq(3).html())
    var price = parseFloat($(this).parent().parent().find('td').eq(4).html())

    if (del < 2) {
        $(this).parent().parent().fadeOut('slow', function () {
            total()
            $(this).remove()
            total()
        })

        total()
    } else {
        $(this).parent().parent().find('td').eq(3).html(--del)
        $(this).parent().parent().find('td').eq(5).html(del * price)

        total()
    }
    

}


function zeroFill(number, width) {
    width -= number.toString().length;
    if (width > 0) {
        return new Array(width + (/\./.test(number) ? 2 : 1)).join('0') + number;
    }
    return number + ""; // siempre devuelve tipo cadena
}

function ltrim(str, chars) {
    chars = chars || "\\s";
    return str.replace(new RegExp("^[" + chars + "]+", "g"), "");
}
