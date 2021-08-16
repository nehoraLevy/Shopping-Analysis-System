using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL_test
{
    class Program
    {
        static void Main(string[] args)
        {

            //DAL.FireBase.QR_deCode.PictureToFireBase("yoghurt.png");

            /* DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Alchogel.png?alt=media&token=61a8d2be-8523-4900-a634-3b6532ff7e2a", "C:\\Users\\batya\\OneDrive\\שולחן העבודה\\Project\\Shopping_project_final\\PLWPF\\images\\alcohogel.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Alchogel.png?alt=media&token=61a8d2be-8523-4900-a634-3b6532ff7e2a", "C:\\Users\\levy\\Desktop\\Shopping_project_final\\PLWPF\\images\\alcohogel.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Apple.png?alt=media&token=340f2876-a4d1-45a3-9b0d-09d4b9f39fee",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\apple.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Body%20soap.png?alt=media&token=c2c6c9dc-95e0-4df1-b080-ec4161f4cf54",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\body_soap.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Carrot.png?alt=media&token=658425ac-5d62-41e9-b3ee-f76916e0fa4d",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\carrot.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Chicken%20Breast.png?alt=media&token=6b905c6e-a938-412f-a03b-013eb6d19ed3",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\chicken_breast.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Chicken.png?alt=media&token=9a533d5b-929b-461c-b0f2-60774decc3b5",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\chicken.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Chocolate%20cake.png?alt=media&token=dd4825e8-8979-4c56-a411-7157ab63efcf",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\cocolate_cake.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Conditioner.png?alt=media&token=26aaf58f-d8ee-4042-8cbb-9e17f3092098",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\conditioner.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Cotton%20sticks.png?alt=media&token=3b790073-ac29-46a6-9e68-ee9b7905c2fe",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\cotton_stick.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Cotton%20wool.png?alt=media&token=ed465b24-32d4-46c1-a8dc-6a4490550f35",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\cotton_whool.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Deodorant%20for%20men.png?alt=media&token=5bc356a2-c4bc-472d-8db4-19af9db6a4c6",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\deodorant_for_men.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Deodorant%20for%20women.png?alt=media&token=cfd1571e-1c4b-4c53-be4d-62c3deafbc1f",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\deodorant_for_women.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Face%20cream.png?alt=media&token=11725d4e-b880-4d77-8a01-9b2a0a8fb8e7",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\face_cream.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Facial%20soap.png?alt=media&token=fa2f78f0-0021-404e-8429-853e599d59c3",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\facial_soap.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Grape%20juice.png?alt=media&token=2043dd08-48fd-464e-9f06-7a279f1dbf9b",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\grapes_juice.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Grapes.png?alt=media&token=65d43b4c-2641-4ad5-b715-c2bb260ca076",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\grapes.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Hair%20cream.png?alt=media&token=516b541d-cb7b-4d78-ab3a-a242c0972a2b",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\hear_cream.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Hand%20cream.png?alt=media&token=51f7383a-2170-474b-9fe0-aed8cb83b9ef",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\hand_cream.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Hand%20soap.png?alt=media&token=07e649ed-90ea-41c8-8565-34d9395a1c0f",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\hand_soap.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Makeup%20remover.png?alt=media&token=707618e5-6deb-4d8b-9a01-a285cbe730d7",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\makeup_remover.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Marble%20cake.png?alt=media&token=41b66fa9-e05a-41b1-a036-7f4e82f2dcd9",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\marbel_cake.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Masks.png?alt=media&token=b07d8724-c24a-41f1-9b62-f3656d6f52ea",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\mask.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Mince.png?alt=media&token=ad4c0c40-cab1-4917-b286-097d91d7dac0",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\minse.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Myslar%20water.png?alt=media&token=3db41917-a7ec-40ba-8f94-eca25078bd43",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\miselar_whater.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Onion.png?alt=media&token=54e5333f-a0de-4ceb-a283-87a2f1b87cd8",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\onion.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Perfume%20for%20men.png?alt=media&token=fbf8b274-6f86-4d7e-9d7b-8a405bf5d89f",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\parfume_for_man.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Perfume%20for%20women.png?alt=media&token=571fb862-444a-4745-bce9-dea6b87af4d4",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\parfume_for_woman.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Razor%20blade.png?alt=media&token=bbaec2ad-cce2-447d-9b93-a45fb12c3d0f",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\razor_blode.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Salomon.png?alt=media&token=4c0a9298-a9e9-47c7-9c7a-0e2d491faba5",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\salmon.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Toilet%20paper.png?alt=media&token=460470ed-551c-4b71-8493-5d3d0f79db41",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\toilet_paper.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Wipes.png?alt=media&token=d7d4a9da-1528-4487-8de6-12e26ac771c3",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\wipps.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/baggt.png?alt=media&token=09817171-49a8-4961-88f9-598b288c6b2f",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\bagget.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/bun.png?alt=media&token=b7e366b2-e448-4c45-b0bc-472816e61b68",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\bun.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/butter.png?alt=media&token=a41c1715-65df-46b1-90a8-661b2a6ff932",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\butter.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/coffee.png?alt=media&token=281937e7-ea7b-483d-8003-cff4f2a3ffbb",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\coffee.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/cookies.png?alt=media&token=d54421ca-d823-4a0a-b4f1-b03a39a739d6",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\coockies.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/cottage.png?alt=media&token=c88aecb8-6836-4256-9778-bf7fc2716175",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\cotteg.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/cucumber.png?alt=media&token=0f823a20-f120-4f27-8203-e397617a51c3",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\cumcumber.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/eggs.png?alt=media&token=9b9265fc-a5c6-4978-8227-84989c24fed0",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\eggs.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/garlic.png?alt=media&token=6160b4c0-cb3a-4394-9b3c-3e87160e92ea",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\face_cream.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/honey.png?alt=media&token=a432dc92-ff3b-4f8b-8c93-6c77d2186370",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\honey.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/jam.png?alt=media&token=f1d8419e-9bf1-4b1e-8421-eb92163d4763",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\jam.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/mango.png?alt=media&token=2944e1dc-a76c-43ac-ae05-447afb41d724",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\mango.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/margarine.png?alt=media&token=47e3953a-08c1-4b4b-8cfe-29c7940a249b",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\margarin.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/melon.png?alt=media&token=77450204-7580-4774-9526-afd39589b66c",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\melon.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/milk11.JPG?alt=media&token=cd76411a-7307-4bb5-939b-22c5be92afc4",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\milk.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/mozzarella.png?alt=media&token=6eca3823-4579-43c9-afa7-da9ee19dd0ae",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\mozzarela.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/orange%20juice.png?alt=media&token=92983d16-0c1e-4821-876e-93c01b793d8b",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\orange_juice.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/pasta.png?alt=media&token=e13954b5-28eb-4707-8eba-9f5b68868c3f",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\pasta.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/pear.png?alt=media&token=36b2654a-4923-4a82-aedc-f1c3016c2b5e",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\pear.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/pepper.png?alt=media&token=984f1a83-0cbf-41af-bd6b-d148f1c39cb1",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\pepper.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/pita.png?alt=media&token=19186b10-1ea1-40fd-895a-f8d9bb4e8718",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\pita.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/rice.png?alt=media&token=5950f304-a3fd-49b6-8b93-57db6286c3bc",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\rice.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/shampoo.png?alt=media&token=5dcd4e06-c425-4206-a718-711234463e22",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\shampoo.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/soy%20sauce.png?alt=media&token=92062837-c901-4832-bb5a-72ad01e82417",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\soy_sause.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/spring%20chicken.png?alt=media&token=ebcbeffb-9737-4e81-9a85-f5bca915a058",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\spring_chikcen.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/tea.png?alt=media&token=02935dd1-8131-4b2a-9fc1-b42a113ee3c5",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\tea.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/tomato.png?alt=media&token=0fee3531-907c-4dca-a940-4d6d67c24dbd",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\tomao.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/toothbrush.png?alt=media&token=5af35c80-6a59-4874-91d5-bff87f21e910",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\toothbrush.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/toothpaste.png?alt=media&token=add0f769-716c-4ff2-9f5d-94f3e0502a9a",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\tooth_past.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/waffle.png?alt=media&token=e547aae6-5783-49ac-8309-9f6928f677f4",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\waffel.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/watermelon.png?alt=media&token=1863604e-47cf-4596-83dc-690a776b0ff6",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\whatermelon.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/wine.png?alt=media&token=93f4d02d-63b4-4ae9-a33c-86a5151c45b3",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\wine.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/yellow%20chese.png?alt=media&token=010becb2-5344-4d5a-b065-e139fcbfadea",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\yellow_chease.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/yoghurt.png?alt=media&token=a64b14dc-d11b-407b-9b35-8b69705abdb5",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\yaourt.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Gloves.png?alt=media&token=d0c7649c-d16d-4f00-ad09-7824d6c034ae",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\gloves.png");
             DAL.FireBase.QR_deCode.showDetails("https://firebasestorage.googleapis.com/v0/b/shoppingprojectfinal.appspot.com/o/Foot%20cream.png?alt=media&token=42a8f962-0160-4428-92fa-ded06a6af8e7",@"C:\Users\batya\OneDrive\שולחן העבודה\Project\Shopping_project_final\PLWPF\images\foot_cream.png");



             //DAL.FireBase.QR_deCode.showDetails("");
             Console.ReadLine();
             var db = new DAL.DalFactory().GetDb();           
             if(db.Categories.Count()==0)
             {
                 Console.WriteLine(db.Categories.Count());
                 var categories = new[] { "milk Products", "Fruits and Vegetable", "Fish and Meat", "Canned food", "Cooking and Baking", "Legumes and sweets ", "Drinks", "Home maintenance and Toiletries " };
                 foreach (var i in categories)
                     db.Categories.Add(new BE.Category { Name = i });
                 db.SaveChanges();
             }
             Console.WriteLine(db.Categories.Count());
            var db = new DAL.DalFactory().GetDb();
            var ct =db.Categories;
            foreach(var i in ct)
            {
                if(i.Name== "milk Products")
                {
                    i.Products.Add(db.Products.Where(c => c.Name.Contains("milk")).FirstOrDefault());
                    i.Products.Add(db.Products.Where(c => c.Name.Contains("butter")).FirstOrDefault());
                    i.Products.Add(db.Products.Where(c => c.Name.Contains("eggs")).FirstOrDefault());
                }
                else if (i.Name == "Fruits and Vegetable")
                {
                    i.Products.Add(db.Products.Where(c => c.Name.Contains("mango")).FirstOrDefault());
                    i.Products.Add(db.Products.Where(c => c.Name.Contains("melon")).FirstOrDefault());
                    i.Products.Add(db.Products.Where(c => c.Name.Contains("watermelon")).FirstOrDefault());
                }
                if (i.Name == "Fish and Meat")
                {
                    i.Products.Add(db.Products.Where(c => c.Name.Contains("Salomon")).FirstOrDefault());
                    i.Products.Add(db.Products.Where(c => c.Name.Contains("chicken")).FirstOrDefault());
                    i.Products.Add(db.Products.Where(c => c.Name.Contains("Chicken Breast")).FirstOrDefault());
                }

                
            var db = new DAL.DalFactory().GetDb();
            if (db.Stores.Count() == 0)
            {
                var stores = new[] { "Rami Levy", "Osher Ad" };
                foreach (var s in stores)
                    db.Stores.Add(new BE.Store { Name = s });
                db.SaveChanges();

            }
            */
        }
            
        }
    }

