1..1
لو حبيت ازود متغير جديد هتوه بين المتغيرات و هنضطر كل شوية نبص على الكونستركتور نتاكد من متغير ما
       call_site Readability   
        لو جه بعد كدا حد قال هنضيف متغير هنحتاج نعمل 
constructor جديد
  أو نغير في كود ال 
 constructor   
القديم    
1...2
      لما نحط كل البيانات دي في 
class واحد 
 ده بيخالف قواعد الoop
 المفروض ال class
 يتكلم عن حاجة واحدة 
  single resposibility  
  *****************************

  3.3

  Single responsibility::
  AddressBuilder     بقى مسؤل فقط عن العناوين 
  InvoiceBuilder   بقى مسؤل عن الفاتورة بس 

========
Independent validation :::
AddressBuilder    بقى بيتأكد ان الشارع و المدينة مكتوبين صح لوحده من غير تدخل الinvoiced

=======
Reuse ::
استخدمنا كود ال AddressBuilder  مرتين

======
Readability at the call site ::
شكل الكود و هو composed بقى شكله احسن و مفهوم اكتر



